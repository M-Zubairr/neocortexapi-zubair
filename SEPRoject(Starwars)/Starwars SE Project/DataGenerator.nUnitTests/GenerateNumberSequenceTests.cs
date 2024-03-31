namespace DataGenerator.nUnitTests
{
    public class GenerateNumberSequenceTests
    {
        // Test case to verify if the generated number sequence has the correct length.
        [Test]
        public void GenerateNumberSequence_ValidLength_ReturnsCorrectLength()
        {
            // Arrange
            int length = 5;

            // Act
            int[] result = EnhanceMultisequenceLearning.DataGenerator.GenerateNumberSequence(length);

            // Assert
            Assert.AreEqual(length, result.Length);
        }

        // Test case to verify if an ArgumentException is thrown when the length is zero.
        [Test]
        public void GenerateNumberSequence_LengthZero_ThrowsArgumentException()
        {
            // Arrange
            int length = 0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => EnhanceMultisequenceLearning.DataGenerator.GenerateNumberSequence(length));
        }

        // Test case to verify if an ArgumentException is thrown when the length is negative.
        [Test]
        public void GenerateNumberSequence_NegativeLength_ThrowsArgumentException()
        {
            // Arrange
            int length = -5;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => EnhanceMultisequenceLearning.DataGenerator.GenerateNumberSequence(length));
        }

        // Test case to verify if the generated number sequence is sorted in ascending order.
        [Test]
        public void GenerateNumberSequence_ResultSortedInAscendingOrder()
        {
            // Arrange
            int length = 10;

            // Act
            int[] result = EnhanceMultisequenceLearning.DataGenerator.GenerateNumberSequence(length);

            // Assert
            Assert.IsTrue(IsSorted(result));
        }

        // Test case to verify if the generated number sequence contains numbers less than 50.
        [Test]
        public void GenerateNumberSequence_ResultContainsNumbersLessThan50()
        {
            // Arrange
            int length = 10;

            // Act
            int[] result = EnhanceMultisequenceLearning.DataGenerator.GenerateNumberSequence(length);

            // Assert
            Assert.IsTrue(result.All(num => num < 50));
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
