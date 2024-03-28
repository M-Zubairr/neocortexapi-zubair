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
        /// Generates a sequence of random uppercase alphabet characters of a given length.
        /// </summary>
        /// <param name="length">The length of the sequence.</param>
        /// <returns>A string representing the generated alphabet sequence.</returns>
        public static string GenerateAlphabetSequence(int length)
        {
            if (length <= 0)
                throw new ArgumentException("Length must be greater than zero.", nameof(length));

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] sequence = new char[length];

            for (int i = 0; i < length; i++)
            {
                var randomChar = chars[random.Next(chars.Length)];
                if (!sequence.Contains(randomChar))
                    sequence[i] = randomChar;
                else
                    i--;
            }

            Array.Sort(sequence);
            return new string(sequence.Distinct().ToArray());
        }

        /// <summary>
        /// Generates multiple alphabet sequences of varying lengths.
        /// </summary>
        /// <param name="numSequences">The number of sequences to generate.</param>
        /// <param name="minLength">The minimum length of each sequence.</param>
        /// <param name="maxLength">The maximum length of each sequence.</param>
        /// <returns>An array of strings representing the generated alphabet sequences.</returns>
        public static string[] GenerateMultiSequenceDatasetForAlphabets(int numSequences, int minLength, int maxLength)
        {
            if (numSequences < 1)
                throw new ArgumentException();

            if (minLength < 1 || maxLength < 1)
                throw new ArgumentException();

            string[] dataset = new string[numSequences];
            for (int i = 0; i < numSequences; i++)
            {
                int length = random.Next(minLength, maxLength + 1);
                dataset[i] = GenerateAlphabetSequence(length);
            }
            return dataset;
        }
    }
}
