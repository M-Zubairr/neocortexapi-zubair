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

        // Prompt the user for the type of data to train the model on
        private string GetDataType()
        {
            Console.WriteLine("Do you want to train the model on numbers or alphabets?");
            Console.WriteLine("1. Numbers");
            Console.WriteLine("2. Alphabets");
            int choice;
            while (true)
            {
                Console.Write("Enter your choice (1/2): ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1 || choice == 2)
                    break;
                Console.WriteLine("Incorrect Option Selected! Please try again.");
            }

            return choice == 1 ? "numbers" : "alphabets";
        }

        // Prompt the user for the number of datasets to train
        private int GetNumberOfDatasets()
        {
            Console.WriteLine("For how many datasets do you want to train? Maximum can be 5 ");
            int choice;
            while (true)
            {
                Console.Write("Enter your choice (1-5): ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice > 0 && choice <= 5)
                    break;
                Console.WriteLine("The number of datasets should be between 1-5. Please try again: ");
            }
            return choice;
        }

        // Generate file names for the datasets
        private string[][] GenerateDatasetFiles(int numDatasets)
        {
            return HelperMethods.GenerateFileNames(numDatasets);
        }

        // Prompt the user for creating new datasets or using existing ones
        private int GetDatasetOption()
        {
            Console.WriteLine("Do you want to create new datasets or start with the existing ones?");
            Console.WriteLine("1. Create a new dataset");
            Console.WriteLine("2. Use an existing dataset");
            int choice;
            while (true)
            {
                Console.Write("Enter your choice (1/2): ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1 || choice == 2)
                    break;
                Console.WriteLine("Incorrect Option Selected! Please try again.");
            }
            return choice;
        }

        // Train models for each dataset
        private void TrainModels(int numDatasets, string[][] datasetFiles, string dataType)
        {
            for (int i = 0; i < numDatasets; i++)
            {
                int index = i; // Capture the current value of i for the thread
                Thread thread = new Thread(() => TrainModel(datasetFiles[index], dataType == "numbers", index));
                thread.Start();
            }
        }
    }
}
