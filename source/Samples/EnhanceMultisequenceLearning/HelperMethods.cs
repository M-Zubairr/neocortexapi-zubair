using EnhanceMultisequenceLearning.Data;
using NeoCortexApi.Encoders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
