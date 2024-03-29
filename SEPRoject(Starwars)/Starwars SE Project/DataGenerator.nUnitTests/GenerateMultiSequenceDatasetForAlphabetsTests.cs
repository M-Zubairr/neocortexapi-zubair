namespace DataGenerator.nUnitTests
{
    public class GenerateMultiSequenceDatasetForAlphabetsTests
    {
        [Test]
        public void GenerateMultiSequenceDatasetForAlphabets_ValidInput_ReturnsCorrectNumberOfSequences()
        {
            // Arrange
            int numSequences = 5;
            int minLength = 3;
            int maxLength = 6;

            // Act
            string[] dataset = EnhanceMultisequenceLearning.DataGenerator.GenerateMultiSequenceDatasetForAlphabets(numSequences, minLength, maxLength);

            // Assert
            Assert.AreEqual(numSequences, dataset.Length);
        }

        [Test]
        public void GenerateMultiSequenceDatasetForAlphabets_MinLengthGreaterThanMaxLength_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int numSequences = 5;
            int minLength = 6;
            int maxLength = 3;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => EnhanceMultisequenceLearning.DataGenerator.GenerateMultiSequenceDatasetForAlphabets(numSequences, minLength, maxLength));
        }

        [Test]
        public void GenerateMultiSequenceDatasetForAlphabets_NegativeNumSequences_ThrowsArgumentException()
        {
            // Arrange
            int numSequences = -5;
            int minLength = 3;
            int maxLength = 6;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => EnhanceMultisequenceLearning.DataGenerator.GenerateMultiSequenceDatasetForAlphabets(numSequences, minLength, maxLength));
        }

        [Test]
        public void GenerateMultiSequenceDatasetForAlphabets_MinLengthZero_ThrowsArgumentException()
        {
            // Arrange
            int numSequences = 5;
            int minLength = 0;
            int maxLength = 6;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => EnhanceMultisequenceLearning.DataGenerator.GenerateMultiSequenceDatasetForAlphabets(numSequences, minLength, maxLength));
        }

        [Test]
        public void GenerateMultiSequenceDatasetForAlphabets_ResultSequencesWithinLengthBounds()
        {
            // Arrange
            int numSequences = 5;
            int minLength = 3;
            int maxLength = 6;

            // Act
            string[] dataset = EnhanceMultisequenceLearning.DataGenerator.GenerateMultiSequenceDatasetForAlphabets(numSequences, minLength, maxLength);

            // Assert
            foreach (var sequence in dataset)
            {
                Assert.GreaterOrEqual(sequence.Length, minLength);
                Assert.LessOrEqual(sequence.Length, maxLength);
            }
        }
    }
}
