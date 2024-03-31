namespace DataGenerator.nUnitTests
{
    public class GenerateNumberSequenceTests
    {
        private Random random = new Random();

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

        [Test]
        public void GenerateNumberSequence_LengthZero_ThrowsArgumentException()
        {
            // Arrange
            int length = 0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => EnhanceMultisequenceLearning.DataGenerator.GenerateNumberSequence(length));
        }

        [Test]
        public void GenerateNumberSequence_NegativeLength_ThrowsArgumentException()
        {
            // Arrange
            int length = -5;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => EnhanceMultisequenceLearning.DataGenerator.GenerateNumberSequence(length));
        }

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
