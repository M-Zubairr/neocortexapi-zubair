namespace DataGenerator.nUnitTests
{
    public class GenerateMultiSequenceDatasetForNumbersTests
    {
        private Random random = new Random();

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
