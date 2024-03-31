namespace DataGenerator.nUnitTests
{
    public class GenerateMultiSequenceDatasetForNumbersTests
    {
        // Test case to verify if the generated dataset contains the correct number of sequences.
        [Test]
        public void GenerateMultiSequenceDatasetForNumbers_ValidInput_ReturnsCorrectNumberOfSequences()
        {
            // Arrange
            int numSequences = 5;
            int minLength = 3;
            int maxLength = 5;

            // Act
            int[][] dataset = EnhanceMultisequenceLearning.DataGenerator.GenerateMultiSequenceDatasetForNumbers(numSequences, minLength, maxLength);

            // Assert
            Assert.AreEqual(numSequences, dataset.Length);
        }

        // Test case to verify if each sequence in the generated dataset falls within the specified length bounds.
        [Test]
        public void GenerateMultiSequenceDatasetForNumbers_ValidInput_ReturnsSequencesWithCorrectLengthRange()
        {
            // Arrange
            int numSequences = 5;
            int minLength = 3;
            int maxLength = 5;

            // Act
            int[][] dataset = EnhanceMultisequenceLearning.DataGenerator.GenerateMultiSequenceDatasetForNumbers(numSequences, minLength, maxLength);

            // Assert
            foreach (int[] sequence in dataset)
            {
                Assert.GreaterOrEqual(sequence.Length, minLength);
                Assert.LessOrEqual(sequence.Length, maxLength);
            }
        }

        // Test case to verify if an ArgumentException is thrown when minLength is negative.
        [Test]
        public void GenerateMultiSequenceDatasetForNumbers_InvalidLength_ThrowsArgumentException()
        {
            // Arrange
            int numSequences = 5;
            int minLength = -3;
            int maxLength = 5;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => EnhanceMultisequenceLearning.DataGenerator.GenerateMultiSequenceDatasetForNumbers(numSequences, minLength, maxLength));
        }

        // Test case to verify if each sequence in the generated dataset is sorted.
        [Test]
        public void GenerateMultiSequenceDatasetForNumbers_ValidInput_ReturnsSequencesSorted()
        {
            // Arrange
            int numSequences = 5;
            int minLength = 3;
            int maxLength = 5;

            // Act
            int[][] dataset = EnhanceMultisequenceLearning.DataGenerator.GenerateMultiSequenceDatasetForNumbers(numSequences, minLength, maxLength);

            // Assert
            foreach (int[] sequence in dataset)
            {
                Assert.IsTrue(IsSorted(sequence));
            }
        }

        // Method to check if an array is sorted.
        private bool IsSorted(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1])
                    return false;
            }
            return true;
        }
    }
}
