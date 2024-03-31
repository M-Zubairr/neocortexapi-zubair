namespace DataGenerator.nUnitTests
{
    public class GenerateRandomIndexesTests
    {
        // Test case to verify if the generated array contains two indexes.
        [Test]
        public void GenerateRandomIndexes_ValidMaxLength_ReturnsArrayWithTwoIndexes()
        {
            // Arrange
            int maxLength = 10;

            // Act
            int[] indexes = EnhanceMultisequenceLearning.DataGenerator.GenerateRandomIndexes(maxLength);

            // Assert
            Assert.AreEqual(2, indexes.Length);
        }

        // Test case to verify if the generated indexes are within the specified range.
        [Test]
        public void GenerateRandomIndexes_IndexesInRange_ReturnsIndexesWithinRange()
        {
            // Arrange
            int maxLength = 10;

            // Act
            int[] indexes = EnhanceMultisequenceLearning.DataGenerator.GenerateRandomIndexes(maxLength);

            // Assert
            Assert.GreaterOrEqual(indexes[0], 0);
            Assert.Less(indexes[0], maxLength);
            Assert.GreaterOrEqual(indexes[1], 0);
            Assert.Less(indexes[1], maxLength);
        }

        // Test case to verify if the difference between the generated indexes is greater than or equal to five.
        [Test]
        public void GenerateRandomIndexes_IndexesWithDifferenceGreaterThanFive_ReturnsIndexesWithDifferenceGreaterThanFive()
        {
            // Arrange
            int maxLength = 10;

            // Act
            int[] indexes = EnhanceMultisequenceLearning.DataGenerator.GenerateRandomIndexes(maxLength);

            // Assert
            Assert.GreaterOrEqual(Math.Abs(indexes[1] - indexes[0]), 5);
        }

        // Test case to verify if an ArgumentException is thrown when maxLength is zero.
        [Test]
        public void GenerateRandomIndexes_MaxLengthZero_ThrowsArgumentException()
        {
            // Arrange
            int maxLength = 0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => EnhanceMultisequenceLearning.DataGenerator.GenerateRandomIndexes(maxLength));
        }

        // Test case to verify if an ArgumentException is thrown when maxLength is negative.
        [Test]
        public void GenerateRandomIndexes_MaxLengthNegative_ThrowsArgumentException()
        {
            // Arrange
            int maxLength = -5;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => EnhanceMultisequenceLearning.DataGenerator.GenerateRandomIndexes(maxLength));
        }
    }
}
