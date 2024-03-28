using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
