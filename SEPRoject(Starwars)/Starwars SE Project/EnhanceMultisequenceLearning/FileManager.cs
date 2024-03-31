using EnhanceMultisequenceLearning.Data;
using Newtonsoft.Json;

namespace EnhanceMultisequenceLearning
{
    public class FileManager
    {
        private const string DatasetFolder = "dataset";
        private const string ReportFolder = "report";
        /// <summary>
        /// Saves an alphabet dataset to files.
        /// </summary>
        /// <param name="dataset">The alphabet dataset to save.</param>
        /// <param name="trainSetPath">The file path for the training set.</param>
        /// <param name="evalSetPath">The file path for the evaluation set.</param>
        /// <param name="testSetPath">The file path for the test set.</param>
        public static void SaveAlphabetDatasetToFile(string[] dataset, string trainSetPath, string evalSetPath, string testSetPath)
        {
            if (dataset == null)
                throw new ArgumentNullException(nameof(dataset));
            if (string.IsNullOrEmpty(trainSetPath))
                throw new ArgumentException("Train set file path is null or empty.", nameof(trainSetPath));
            if (string.IsNullOrEmpty(evalSetPath))
                throw new ArgumentException("Evaluation set file path is null or empty.", nameof(evalSetPath));
            if (string.IsNullOrEmpty(testSetPath))
                throw new ArgumentException("Test set file path is null or empty.", nameof(testSetPath));

            string path = EnsureDirectory($"{DatasetFolder}/alphabets");
            using (StreamWriter writerTrain = new StreamWriter($"{path}/{trainSetPath}"))
            using (StreamWriter writerEval = new StreamWriter($"{path}/{evalSetPath}"))
            using (StreamWriter writerTest = new StreamWriter($"{path}/{testSetPath}"))
            {
                WriteAlphabetDataset(writerTrain, dataset, "S", true);
                WriteAlphabetDataset(writerEval, dataset, "E", false);
                WriteAlphabetDataset(writerTest, dataset, "T", false);
            }
        }
        /// <summary>
        /// Writes an alphabet dataset to a StreamWriter.
        /// </summary>
        /// <param name="writer">The StreamWriter to write to.</param>
        /// <param name="dataset">The alphabet dataset.</param>
        /// <param name="prefix">The prefix for each entry.</param>
        /// <param name="isFirstSet">Indicates if this is the first set.</param>
        private static void WriteAlphabetDataset(StreamWriter writer, string[] dataset, string prefix, bool isFirstSet)
        {
            writer.WriteLine("[");
            for (int i = 0; i < dataset.Length; i++)
            {
                if (i != 0)
                    writer.WriteLine(",");

                int startIndex = 0;
                int length = dataset[i].Length;

                if (!isFirstSet)
                {
                    int[] indexes = DataGenerator.GenerateRandomIndexes(dataset[i].Length);
                    startIndex = indexes[0];
                    length = indexes[1] - indexes[0];
                }

                writer.WriteLine($"{{\"name\": \"{prefix}{i + 1}\", \"data\": \"{dataset[i].Substring(startIndex, length)}\"}}");
            }
            writer.WriteLine("]");
        }
        /// <summary>
        /// Saves a number dataset to files.
        /// </summary>
        /// <param name="dataset">The number dataset to save.</param>
        /// <param name="trainSetPath">The file path for the training set.</param>
        /// <param name="evalSetPath">The file path for the evaluation set.</param>
        /// <param name="testSetPath">The file path for the test set.</param>
        public static void SaveNumberDatasetToFile(int[][] dataset, string trainSetPath, string evalSetPath, string testSetPath)
        {
            if (dataset == null)
                throw new ArgumentNullException(nameof(dataset));
            if (string.IsNullOrEmpty(trainSetPath))
                throw new ArgumentException("Train set file path is null or empty.", nameof(trainSetPath));
            if (string.IsNullOrEmpty(evalSetPath))
                throw new ArgumentException("Evaluation set file path is null or empty.", nameof(evalSetPath));
            if (string.IsNullOrEmpty(testSetPath))
                throw new ArgumentException("Test set file path is null or empty.", nameof(testSetPath));

            string path = EnsureDirectory($"{DatasetFolder}/numbers");
            using (StreamWriter writerTrain = new StreamWriter($"{path}/{trainSetPath}"))
            using (StreamWriter writerEval = new StreamWriter($"{path}/{evalSetPath}"))
            using (StreamWriter writerTest = new StreamWriter($"{path}/{testSetPath}"))
            {
                WriteNumberDataset(writerTrain, dataset, "S", true);
                WriteNumberDataset(writerEval, dataset, "E", false);
                WriteNumberDataset(writerTest, dataset, "T", false);
            }
        }
        /// <summary>
        /// Writes a number dataset to a StreamWriter.
        /// </summary>
        /// <param name="writer">The StreamWriter to write to.</param>
        /// <param name="dataset">The number dataset.</param>
        /// <param name="prefix">The prefix for each entry.</param>
        /// <param name="isFirstSet">Indicates if this is the first set.</param>
        private static void WriteNumberDataset(StreamWriter writer, int[][] dataset, string prefix, bool isFirstSet)
        {
            writer.WriteLine("[");
            for (int i = 0; i < dataset.Length; i++)
            {
                if (i != 0)
                    writer.WriteLine(",");

                int startIndex = 0;
                int length = dataset[i].Length;

                if (!isFirstSet)
                {
                    int[] indexes = DataGenerator.GenerateRandomIndexes(dataset[i].Length);
                    startIndex = indexes[0];
                    length = indexes[1] - indexes[0];
                }

                writer.WriteLine($"{{\"name\": \"{prefix}{i + 1}\", \"data\": {JsonConvert.SerializeObject(HelperMethods.GetSubArray(dataset[i], startIndex, length))}}}");
            }
            writer.WriteLine("]");
        }
        /// <summary>
        /// Reads a dataset from a file and deserializes it to the specified type.
        /// </summary>
        /// <typeparam name="T">The type of data to deserialize.</typeparam>
        /// <param name="basePath">The base path where the dataset is located.</param>
        /// <param name="filename">The name of the file containing the dataset.</param>
        /// <returns>The deserialized dataset.</returns>
        public static List<T> ReadDataset<T>(string basePath, string filename)
        {
            // Determine the dataset path based on the type T
            string datasetPath = Path.Combine(basePath, DatasetFolder, filename);
            if (typeof(T) == typeof(Sequence))
                datasetPath = Path.Combine(basePath, $"{DatasetFolder}/numbers", filename);
            else
                datasetPath = Path.Combine(basePath, $"{DatasetFolder}/alphabets", filename);

            try
            {
                Console.WriteLine($"Reading Dataset: {datasetPath}");
                return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(datasetPath));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading dataset: {ex.Message}");
                return new List<T>();
            }
        }

        /// <summary>
        /// Writes reports to a file.
        /// </summary>
        /// <param name="reports">The reports to be written.</param>
        /// <param name="basePath">The base path where the reports will be saved.</param>
        public static void WriteReport(List<Report> reports, string basePath)
        {
            string reportFolder = EnsureDirectory(Path.Combine(basePath, ReportFolder));
            string reportPath = Path.Combine(reportFolder, $"report_{DateTime.Now.Ticks}.txt");

            using (StreamWriter sw = File.CreateText(reportPath))
            {
                foreach (Report report in reports)
                {
                    WriteReportContent(sw, report);
                }
            }
        }


        /// <summary>
        /// Ensures that a directory exists; if not, creates it.
        /// </summary>
        /// <param name="path">The directory path.</param>
        /// <returns>The provided directory path.</returns>
        private static string EnsureDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }
        /// <summary>
        /// Writes the content of a report to a StreamWriter.
        /// </summary>
        /// <param name="sw">The StreamWriter to write to.</param>
        /// <param name="report">The report to write.</param>
        private static void WriteReportContent(StreamWriter sw, Report report)
        {
            sw.WriteLine("------------------------------");
            sw.WriteLine($"Using test sequence: {report.SequenceName} -> {string.Join("-", report.SequenceData)}");
            foreach (string log in report.PredictionLog)
            {
                sw.WriteLine($"\t{log}");
            }
            sw.WriteLine($"\tAccuracy: {report.Accuracy}%");
            sw.WriteLine("------------------------------");
        }
    }
}
