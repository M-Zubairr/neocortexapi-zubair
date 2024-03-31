namespace DataGenerator.nUnitTests
{
    public class GenerateAlphabetSequence
    {
        [Test]
        public void GenerateAlphabetSequence_ValidLength_ReturnsCorrectLength()
        {
            // Arrange
            int length = 5;

            // Act
            string result = EnhanceMultisequenceLearning.DataGenerator.GenerateAlphabetSequence(length);

            // Assert
            Assert.AreEqual(length, result.Length);
        }

        [Test]
        public void GenerateAlphabetSequence_LengthZero_ThrowsArgumentException()
        {
            // Arrange
            int length = 0;

            // Act & Assert///
            Assert.Throws<ArgumentException>(() => EnhanceMultisequenceLearning.DataGenerator.GenerateAlphabetSequence(length));
        }

        [Test]
        public void GenerateAlphabetSequence_NegativeLength_ThrowsArgumentException()
        {
            // Arrange
            int length = -5;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => EnhanceMultisequenceLearning.DataGenerator.GenerateAlphabetSequence(length));
        }

        [Test]
        public void GenerateAlphabetSequence_ResultContainsOnlyUpperCaseLetters()
        {
            // Arrange
            int length = 10;

            // Act
            string result = EnhanceMultisequenceLearning.DataGenerator.GenerateAlphabetSequence(length);

            // Assert
            Assert.IsTrue(result.All(char.IsUpper));
        }

        [Test]
        public void GenerateAlphabetSequence_ResultContainsDistinctLetters()
        {
            // Arrange
            int length = 10;

            // Act
            string result = EnhanceMultisequenceLearning.DataGenerator.GenerateAlphabetSequence(length);

            // Assert
            Assert.AreEqual(length, result.Distinct().Count());
        }
    }
}