using EnhanceMultisequenceLearning.Data;

namespace HelperMethods.nUnitTests
{
    public class TransformDataTests
    {
        // Test case to verify if the method returns an empty list when input list is empty.
        [Test]
        public void TransformData_EmptyList_ReturnsEmptyList()
        {
            // Arrange
            List<SequenceString> data = new List<SequenceString>();

            // Act
            List<Sequence> transformedData = EnhanceMultisequenceLearning.HelperMethods.TransformData(data);

            // Assert
            Assert.IsEmpty(transformedData);
        }

        // Test case to verify if the method returns transformed data for valid input.
        [Test]
        public void TransformData_ValidData_ReturnsTransformedData()
        {
            // Arrange
            List<SequenceString> data = new List<SequenceString>
            {
                new SequenceString { name = "Sequence1", data = "ABC" },
                new SequenceString { name = "Sequence2", data = "DEF" }
            };

            // Act
            List<Sequence> transformedData = EnhanceMultisequenceLearning.HelperMethods.TransformData(data);

            // Assert
            Assert.AreEqual(2, transformedData.Count);
            Assert.AreEqual("Sequence1", transformedData[0].name);
            Assert.AreEqual(new List<int> { 97, 98, 99 }, transformedData[0].data);
            Assert.AreEqual("Sequence2", transformedData[1].name);
            Assert.AreEqual(new List<int> { 100, 101, 102 }, transformedData[1].data);
        }

        // Test case to verify if an ArgumentNullException is thrown when input is null.
        [Test]
        public void TransformData_NullInput_ThrowsArgumentNullException()
        {
            // Arrange
            List<SequenceString> data = null;

            // Act & Assert
            Assert.Throws<System.ArgumentNullException>(() => EnhanceMultisequenceLearning.HelperMethods.TransformData(data));
        }
    }
}
