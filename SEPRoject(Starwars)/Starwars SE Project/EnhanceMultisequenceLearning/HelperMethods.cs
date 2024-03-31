using NeoCortexApi;
using NeoCortexApi.Encoders;
using NeoCortexApi.Entities;
using Newtonsoft.Json;
using EnhanceMultisequenceLearning.Data;

namespace EnhanceMultisequenceLearning
{
    public class HelperMethods
    {
        // Constants for default settings
        private const int DefaultRandomSeed = 42;

        // Avoid magic numbers in your code
        private const int DefaultCellsPerColumn = 25;
        private const double DefaultGlobalInhibitionDensity = 0.02;
        private const double DefaultPotentialRadiusFactor = 0.15;
        private const double DefaultMaxSynapsesPerSegmentFactor = 0.02;
        private const double DefaultMaxBoost = 10.0;
        private const int DefaultDutyCyclePeriod = 25;
        private const double DefaultMinPctOverlapDutyCycles = 0.75;
        private const int DefaultActivationThreshold = 15;
        private const double DefaultConnectedPermanence = 0.5;
        private const double DefaultPermanenceDecrement = 0.25;
        private const double DefaultPermanenceIncrement = 0.15;
        private const double DefaultPredictedSegmentDecrement = 0.1;

        /// <summary>
        /// HTM Config for creating Connections
        /// </summary>
        public static HtmConfig FetchHTMConfig(int inputBits, int numColumns)
        {
            return new HtmConfig(new int[] { inputBits }, new int[] { numColumns })
            {
                Random = new ThreadSafeRandom(DefaultRandomSeed),
                CellsPerColumn = DefaultCellsPerColumn,
                GlobalInhibition = true,
                LocalAreaDensity = -1,
                NumActiveColumnsPerInhArea = DefaultGlobalInhibitionDensity * numColumns,
                PotentialRadius = (int)(DefaultPotentialRadiusFactor * inputBits),
                MaxBoost = DefaultMaxBoost,
                DutyCyclePeriod = DefaultDutyCyclePeriod,
                MinPctOverlapDutyCycles = DefaultMinPctOverlapDutyCycles,
                MaxSynapsesPerSegment = (int)(DefaultMaxSynapsesPerSegmentFactor * numColumns),
                ActivationThreshold = DefaultActivationThreshold,
                ConnectedPermanence = DefaultConnectedPermanence,
                PermanenceDecrement = DefaultPermanenceDecrement,
                PermanenceIncrement = DefaultPermanenceIncrement,
                PredictedSegmentDecrement = DefaultPredictedSegmentDecrement
            };
        }

        /// <summary>
        /// Get the encoder with settings
        /// </summary>
        public static EncoderBase GetEncoderForNumberSequence(int inputBits)
        {
            var settings = new Dictionary<string, object>
            {
                { "W", 15 },
                { "N", inputBits },
                { "Radius", -1.0 },
                { "MinVal", 0.0 },
                { "Periodic", false },
                { "Name", "scalar" },
                { "ClipInput", false },
                { "MaxVal", 50.0 }
            };

            return new ScalarEncoder(settings);
        }

        /// <summary>
        /// Get the encoder with settings
        /// </summary>
        public static EncoderBase GetEncoderForAlphabetSequence(int inputBits)
        {
            var settings = new Dictionary<string, object>
            {
                { "W", 15 },
                { "N", inputBits },
                { "Radius", -1.0 },
                { "MinVal", 97.0 },
                { "Periodic", false },
                { "Name", "scalar" },
                { "ClipInput", false },
                { "MaxVal", 122.0 }
            };

            return new ScalarEncoder(settings);
        }

        /// <summary>
        /// Reads dataset from the file
        /// </summary>
        public static List<Sequence> ReadDataset(string path)
        {
            Console.WriteLine("Reading Sequence...");
            try
            {
                string fileContent = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<List<Sequence>>(fileContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to read the dataset: {ex.Message}");
                return new List<Sequence>(); // Return an empty list in case of failure
            }
        }

        /// <summary>
        /// Saves the dataset in 'dataset' folder in BasePath of application
        /// </summary>
        public static string SaveDataset(List<Sequence> sequences)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string datasetFolder = Path.Combine(basePath, "dataset");
            Directory.CreateDirectory(datasetFolder); // CreateDirectory is safe to call if directory exists
            string datasetPath = Path.Combine(datasetFolder, $"dataset_{DateTime.Now.Ticks}.json");

            Console.WriteLine("Saving dataset...");
            File.WriteAllText(datasetPath, JsonConvert.SerializeObject(sequences));
            return datasetPath;
        }

        /// <summary>
        /// Creates multiple sequences as per parameters
        /// </summary>
        public static List<Sequence> CreateSequences(int count, int size, int startVal, int stopVal)
        {
            return Enumerable.Range(1, count).Select(i =>
                new Sequence
                {
                    name = $"S{i}",
                    data = GenerateRandomSequence(size, startVal, stopVal)
                })
                .ToList();
        }
        /// <summary>
        /// Generates a random sequence of unique integers within a specified range.
        /// </summary>
        /// <param name="size">The number of elements in the sequence.</param>
        /// <param name="startVal">The inclusive lower bound of the range.</param>
        /// <param name="stopVal">The inclusive upper bound of the range.</param>
        /// <returns>An array containing a random sequence of unique integers.</returns>
        private static int[] GenerateRandomSequence(int size, int startVal, int stopVal)
        {
            var rnd = new Random();
            var sequence = new HashSet<int>();

            while (sequence.Count < size)
            {
                int number = rnd.Next(startVal, stopVal + 1);
                sequence.Add(number);
            }

            return sequence.OrderBy(n => n).ToArray();
        }
        /// <summary>
        /// Converts characters to their corresponding ASCII values.
        /// </summary>
        /// <param name="characters">The string containing characters to convert.</param>
        /// <returns>An array of integers representing the ASCII values of the characters.</returns>
        public static int[] ConvertToAscii(string characters)
        {
            List<int> asciiValues = new List<int>();

            if (characters == null)
                throw new ArgumentNullException();

            foreach (char character in characters.ToLower())
            {
                if (character >= 'a' && character <= 'z')
                {
                    int asciiValue = (int)character;
                    asciiValues.Add(asciiValue);
                }
            }

            return asciiValues.ToArray();
        }
        // <summary>
        /// Generates filenames for datasets based on the given number.
        /// </summary>
        /// <param name="numOfFiles">The number of files to generate filenames for.</param>
        /// <returns>An array of string arrays containing filenames for each dataset.</returns>
        public static string[][] GenerateFileNames(int numOfFiles)
        {
            if (numOfFiles < 0)
                throw new ArgumentException();

            string[][] filenamesArray = new string[numOfFiles][];
            for (int i = 0; i < numOfFiles; i++)
            {
                filenamesArray[i] = [$"dataset_0{i + 1}", $"eval_0{i + 1}", $"test_0{i + 1}"];
            }

            return filenamesArray;
        }
        /// <summary>
        /// Transforms a list of SequenceString into a list of Sequence.
        /// </summary>
        /// <param name="data">The list of SequenceString to transform.</param>
        /// <returns>A list of Sequence objects.</returns>
        public static List<Sequence> TransformData(List<SequenceString> data)
        {
            if (data == null)
                throw new ArgumentNullException();

            List<Sequence> transformedData = new List<Sequence>();
            foreach (var x in data)
            {
                transformedData.Add(new Sequence() { name = x.name, data = HelperMethods.ConvertToAscii(x.data) });
            }
            return transformedData;
        }
        // <summary>
        /// Retrieves a subarray from the given array.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The source array.</param>
        /// <param name="startIndex">The starting index of the subarray.</param>
        /// <param name="length">The length of the subarray.</param>
        /// <returns>A subarray containing elements from the source array.</returns>
        public static T[] GetSubArray<T>(T[] array, int startIndex, int length)
        {
            if (startIndex < 0 || startIndex >= array.Length || length <= 0 || startIndex + length > array.Length)
                throw new ArgumentException("Invalid startIndex or length.");

            T[] subArray = new T[length];
            Array.Copy(array, startIndex, subArray, 0, length);
            return subArray;
        }

    }
}