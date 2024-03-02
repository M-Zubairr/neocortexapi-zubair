int numSequences = 100;
int minSequenceLength = 20;
int maxSequenceLength = 50;

string[] dataset = SequenceGenerator.SequenceGenerator.GenerateMultiSequenceDataset(numSequences, minSequenceLength, maxSequenceLength);
SequenceGenerator.SequenceGenerator.SaveDatasetToFile(dataset, "multisequence_dataset.txt");