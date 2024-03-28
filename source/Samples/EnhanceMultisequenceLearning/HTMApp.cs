using EnhanceMultisequenceLearning.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhanceMultisequenceLearning
{
    public class HTMApp
    {
        private void CreateNewDatasets(string dataType, string[][] datasetFiles)
        {
            Console.Write("Enter total sequences in the dataset: ");
            int totalSequences = Convert.ToInt32(Console.ReadLine());
            int minLength;
            int maxLength;
            while (true)
            {
                Console.Write("Minimum sequence length should be 10\nEnter minimum sequence length: ");
                while (true)
                {
                    minLength = Convert.ToInt32(Console.ReadLine());
                    if (minLength >= 10)
                        break;
                    Console.Write("Minimum sequence length is less than 10. Try Again: ");
                }
                Console.Write("Enter maximum sequence length: ");
                maxLength = Convert.ToInt32(Console.ReadLine());

                if (minLength < maxLength)
                    break;

                Console.WriteLine("Minimum sequence length should be less than maximum sequence length. Try Again!");
            }

            // Generate and save datasets based on data type
            if (dataType == "alphabets")
            {
                for (int i = 0; i < datasetFiles.Length; i++)
                {
                    var dataset = DataGenerator.GenerateMultiSequenceDatasetForAlphabets(totalSequences, minLength, maxLength);
                    FileManager.SaveAlphabetDatasetToFile(dataset, datasetFiles[i][0], datasetFiles[i][1], datasetFiles[i][2]);
                }
            }
            else
            {
                for (int i = 0; i < datasetFiles.Length; i++)
                {
                    var dataset = DataGenerator.GenerateMultiSequenceDatasetForNumbers(totalSequences, minLength, maxLength);
                    FileManager.SaveNumberDatasetToFile(dataset, datasetFiles[i][0], datasetFiles[i][1], datasetFiles[i][2]);
                }
            }
        }

        private void TrainModel(string[] datasetFiles, bool isNumberDataset, int index)
        {
            // Initialize reports list
            List<Report> reports;

            // Get base path for file operations
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            // Read datasets based on data type
            if (!isNumberDataset)
            {
                List<SequenceString> sequencesString = FileManager.ReadDataset<SequenceString>(basePath, datasetFiles[0]);
                List<SequenceString> sequencesEvalString = FileManager.ReadDataset<SequenceString>(basePath, datasetFiles[1]);
                List<SequenceString> sequencesTestString = FileManager.ReadDataset<SequenceString>(basePath, datasetFiles[2]);

                // Run experiment and get reports
                reports = ModelTrainer.RunMultiSequenceLearningExperiment(
                    HelperMethods.TransformData(sequencesString),
                    HelperMethods.TransformData(sequencesEvalString),
                    HelperMethods.TransformData(sequencesTestString), false, index);
            }
            else
            {
                List<Sequence> sequences = FileManager.ReadDataset<Sequence>(basePath, datasetFiles[0]);
                List<Sequence> sequencesEval = FileManager.ReadDataset<Sequence>(basePath, datasetFiles[1]);
                List<Sequence> sequencesTest = FileManager.ReadDataset<Sequence>(basePath, datasetFiles[2]);

                // Run experiment and get reports
                reports = ModelTrainer.RunMultiSequenceLearningExperiment(sequences, sequencesEval, sequencesTest, true, index);
            }

            // Write reports to file
            FileManager.WriteReport(reports, basePath);
        }

        public void Start()
        {
            // Welcome message
            Console.WriteLine("Welcome to HTM Model Trainer!");

            // Get the type of data to train the model on
            string dataType = GetDataType();

            // Get the number of datasets to train
            int numDatasets = GetNumberOfDatasets();

            // Generate file names for the datasets
            var datasetFiles = GenerateDatasetFiles(numDatasets);

            // Get user choice for creating new datasets or using existing ones
            int choice = GetDatasetOption();

            // Process user choice
            if (choice == 1)
            {
                // Create new datasets
                CreateNewDatasets(dataType, datasetFiles);
            }
            else if (choice != 2)
            {
                // Invalid choice, exiting
                Console.WriteLine("Invalid choice. Exiting...");
                return;
            }

            // Train models based on the datasets
            TrainModels(numDatasets, datasetFiles, dataType);

            // Wait for user input before exiting
            Console.ReadLine();
        }


    }
}
