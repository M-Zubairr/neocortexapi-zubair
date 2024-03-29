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

    /// <summary>
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

    /// <summary>
    /// Generates random indexes within a given range, ensuring a minimum distance of 5 between them.
    /// </summary>
    /// <param name="maxLength">The maximum index value.</param>
    /// <returns>An array containing two random indexes.</returns>
    public static int[] GenerateRandomIndexes(int maxLength)
    {
        if (maxLength < 5)
            throw new ArgumentException();

        int[] indexes = new int[2];
        indexes[0] = random.Next(0, maxLength);
        indexes[1] = random.Next(0, maxLength);

        while (Math.Abs(indexes[0] - indexes[1]) < 5)
        {
            indexes[0] = random.Next(0, maxLength);
            indexes[1] = random.Next(0, maxLength);
        }

        Array.Sort(indexes);
        return indexes;
    }



}
