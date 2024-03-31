namespace HelperMethods.nUnitTests
{
    public class ConvertToAsciiTests
    {
        // Test case to verify if the method returns the correct ASCII values for valid input.
        [Test]
        public void ConvertToAscii_ValidInput_ReturnsCorrectAsciiValues()
        {
            // Arrange
            string characters = "abc";
            int[] expected = { 97, 98, 99 };

            // Act
            int[] result = EnhanceMultisequenceLearning.HelperMethods.ConvertToAscii(characters);

            // Assert
            Assert.AreEqual(expected, result);
        }

        // Test case to verify if the method returns an empty array for empty input.
        [Test]
        public void ConvertToAscii_EmptyInput_ReturnsEmptyArray()
        {
            // Arrange
            string characters = "";

            // Act
            int[] result = EnhanceMultisequenceLearning.HelperMethods.ConvertToAscii(characters);

            // Assert
            Assert.IsEmpty(result);
        }

        // Test case to verify if an ArgumentNullException is thrown for null input.
        [Test]
        public void ConvertToAscii_NullInput_ThrowsArgumentNullException()
        {
            // Arrange
            string characters = null;

            // Act & Assert
            Assert.Throws<System.ArgumentNullException>(() => EnhanceMultisequenceLearning.HelperMethods.ConvertToAscii(characters));
        }

        // Test case to verify if the method returns ASCII values only for letters when input contains special characters.
        [Test]
        public void ConvertToAscii_InputWithSpecialCharacters_ReturnsAsciiValuesForLettersOnly()
        {
            // Arrange
            string characters = "a!b@c#";
            int[] expected = { 97, 98, 99 };

            // Act
            int[] result = EnhanceMultisequenceLearning.HelperMethods.ConvertToAscii(characters);

            // Assert
            Assert.AreEqual(expected, result);
        }

        // Test case to verify if the method returns ASCII values for lowercase letters when input contains uppercase letters.
        [Test]
        public void ConvertToAscii_InputWithUpperCaseLetters_ReturnsAsciiValuesForLowerCaseLetters()
        {
            // Arrange
            string characters = "ABC";
            int[] expected = { 97, 98, 99 };

            // Act
            int[] result = EnhanceMultisequenceLearning.HelperMethods.ConvertToAscii(characters);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
