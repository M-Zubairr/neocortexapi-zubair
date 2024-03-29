using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceGenerator
{
    public static class SequenceGenerator
    {
        static Random random = new Random();

        public static string GenerateSequence(int length)
        {
            StringBuilder sequenceBuilder = new StringBuilder();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < length; i++)
            {
                sequenceBuilder.Append(chars[random.Next(chars.Length)]);
            }
            return sequenceBuilder.ToString();
        }

        public static string[] GenerateMultiSequenceDataset(int numSequences, int minLength, int maxLength)
        {
            string[] dataset = new string[numSequences];
            for (int i = 0; i < numSequences; i++)
            {
                int length = random.Next(minLength, maxLength + 1);
                dataset[i] = GenerateSequence(length);
            }
            return dataset;
        }

        public static void SaveDatasetToFile(string[] dataset, string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                for (int i = 0; i < dataset.Length; i++)
                {
                    writer.WriteLine($"S{i + 1}: {dataset[i]}");
                }
            }
        }
    }
}
