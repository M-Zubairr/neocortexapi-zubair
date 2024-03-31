namespace HelperMethods.nUnitTests
{
    public class GenerateFileNamesTests
    {
        // Test case to verify if the method returns the correct number of file names.
        [Test]
        public void GenerateFileNames_ValidInput_ReturnsCorrectNumberOfFiles()
        {
            // Arrange
            int numOfFiles = 3;

            // Act
            string[][] result = EnhanceMultisequenceLearning.HelperMethods.GenerateFileNames(numOfFiles);

            // Assert
            Assert.AreEqual(numOfFiles, result.Length);
        }

        // Test case to verify if the method returns file names in the correct format.
        [Test]
        public void GenerateFileNames_ValidInput_ReturnsCorrectFileNamesFormat()
        {
            // Arrange
            int numOfFiles = 3;
            string[][] expected = {
                new string[] { "dataset_01", "eval_01", "test_01" },
                new string[] { "dataset_02", "eval_02", "test_02" },
                new string[] { "dataset_03", "eval_03", "test_03" }
            };

            // Act
            string[][] result = EnhanceMultisequenceLearning.HelperMethods.GenerateFileNames(numOfFiles);

            // Assert
            Assert.AreEqual(expected, result);
        }

        // Test case to verify if the method returns an empty array when the number of files is zero.
        [Test]
        public void GenerateFileNames_ZeroNumberOfFiles_ReturnsEmptyArray()
        {
            // Arrange
            int numOfFiles = 0;

            // Act
            string[][] result = EnhanceMultisequenceLearning.HelperMethods.GenerateFileNames(numOfFiles);

            // Assert
            Assert.IsEmpty(result);
        }

        // Test case to verify if an ArgumentException is thrown when the number of files is negative.
        [Test]
        public void GenerateFileNames_NegativeNumberOfFiles_ThrowsArgumentException()
        {
            // Arrange
            int numOfFiles = -3;

            // Act & Assert
            Assert.Throws<System.ArgumentException>(() => EnhanceMultisequenceLearning.HelperMethods.GenerateFileNames(numOfFiles));
        }
    }
}
