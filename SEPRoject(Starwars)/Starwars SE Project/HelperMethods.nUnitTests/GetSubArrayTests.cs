namespace HelperMethods.nUnitTests
{
    public class GetSubArrayTests
    {
        [Test]
        public void GetSubArray_ValidInput_ReturnsCorrectSubArray()
        {
            // Arrange
            int[] array = { 1, 2, 3, 4, 5 };
            int startIndex = 1;
            int length = 3;
            int[] expected = { 2, 3, 4 };

            // Act
            int[] result = EnhanceMultisequenceLearning.HelperMethods.GetSubArray(array, startIndex, length);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetSubArray_StartIndexNegative_ThrowsArgumentException()
        {
            // Arrange
            int[] array = { 1, 2, 3, 4, 5 };
            int startIndex = -1;
            int length = 3;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => EnhanceMultisequenceLearning.HelperMethods.GetSubArray(array, startIndex, length));
        }

        [Test]
        public void GetSubArray_LengthZero_ThrowsArgumentException()
        {
            // Arrange
            int[] array = { 1, 2, 3, 4, 5 };
            int startIndex = 2;
            int length = 0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => EnhanceMultisequenceLearning.HelperMethods.GetSubArray(array, startIndex, length));
        }

        [Test]
        public void GetSubArray_IndexOutOfRange_ThrowsArgumentException()
        {
            // Arrange
            int[] array = { 1, 2, 3, 4, 5 };
            int startIndex = 4;
            int length = 2;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => EnhanceMultisequenceLearning.HelperMethods.GetSubArray(array, startIndex, length));
        }

        [Test]
        public void GetSubArray_LengthOutOfRange_ThrowsArgumentException()
        {
            // Arrange
            int[] array = { 1, 2, 3, 4, 5 };
            int startIndex = 2;
            int length = 4;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => EnhanceMultisequenceLearning.HelperMethods.GetSubArray(array, startIndex, length));
        }

        [Test]
        public void GetSubArray_LengthExceedsArrayLength_ThrowsArgumentException()
        {
            // Arrange
            int[] array = { 1, 2, 3, 4, 5 };
            int startIndex = 2;
            int length = 5;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => EnhanceMultisequenceLearning.HelperMethods.GetSubArray(array, startIndex, length));
        }
    }
}