namespace DataGenerator.nUnitTests
{
    public class GenerateAlphabetSequence
    {
        // Test case to verify if the generated alphabet sequence has the correct length.
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

        // Test case to verify if an ArgumentException is thrown when the length is zero.
        [Test]
        public void GenerateAlphabetSequence_LengthZero_ThrowsArgumentException()
        {
            // Arrange
            int length = 0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => EnhanceMultisequenceLearning.DataGenerator.GenerateAlphabetSequence(length));
        }

        // Test case to verify if an ArgumentException is thrown when the length is negative.
        [Test]
        public void GenerateAlphabetSequence_NegativeLength_ThrowsArgumentException()
        {
            // Arrange
            int length = -5;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => EnhanceMultisequenceLearning.DataGenerator.GenerateAlphabetSequence(length));
        }

        // Test case to verify if the generated alphabet sequence contains only uppercase letters.
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

        // Test case to verify if the generated alphabet sequence contains distinct letters.
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
