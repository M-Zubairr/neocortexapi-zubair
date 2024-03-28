using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhanceMultisequenceLearning
{
    public class DataGenerator
    {
        private static Random random = new Random();

        /// <summary>
        /// Generates a sequence of random integers within a specified range.
        /// </summary>
        /// <param name="length">The length of the sequence.</param>
        /// <returns>An array of integers representing the generated number sequence.</returns>
        public static int[] GenerateNumberSequence(int length)
        {
            if (length <= 0)
                throw new ArgumentException("Length must be greater than zero.", nameof(length));

            int[] sequence = new int[length];

            for (int i = 0; i < length; i++)
            {
                sequence[i] = random.Next(50);
            }

            Array.Sort(sequence);
            return sequence;
        }

        /// <summary>///
        /// Generates multiple number sequences of varying lengths.
        /// </summary>
        /// <param name="numSequences">The number of sequences to generate.</param>
        /// <param name="minLength">The minimum length of each sequence.</param>
        /// <param name="maxLength">The maximum length of each sequence.</param>
        /// <returns>An array of arrays of integers representing the generated number sequences.</returns>
        public static int[][] GenerateMultiSequenceDatasetForNumbers(int numSequences, int minLength, int maxLength)
        {
            if (numSequences < 1 || minLength < 1 || maxLength < 1)
                throw new ArgumentException();

            int[][] dataset = new int[numSequences][];
            for (int i = 0; i < numSequences; i++)
            {
                int length = random.Next(minLength, maxLength + 1);
                dataset[i] = GenerateNumberSequence(length);
            }
            return dataset;
        }

    }
}
