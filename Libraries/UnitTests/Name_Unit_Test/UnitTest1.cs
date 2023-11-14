
namespace Name_Unit_Test
{
    public class UnitTest1
    {
        [Fact]
        public void NameValidation_ValidName_ReturnsTrue()
        {
            // Arrange
            string validName = "JohnDoe";

            // Act
            bool result = UI.NameValidation(validName);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void NameValidation_NameWithNumbers_ReturnsFalse()
        {
            // Arrange
            string nameWithNumbers = "John123";

            // Act
            bool result = UI.NameValidation(nameWithNumbers);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void NameValidation_NameWithSpecialCharacters_ReturnsFalse()
        {
            // Arrange
            string nameWithSpecialChars = "John@Doe";

            // Act
            bool result = UI.NameValidation(nameWithSpecialChars);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void NameValidation_NameWithNumbersAndSpecialCharacters_ReturnsFalse()
        {
            // Arrange
            string invalidName = "John123@Doe";

            // Act
            bool result = UI.NameValidation(invalidName);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void NameValidation_EmptyName_ReturnsFalse()
        {
            // Arrange
            string emptyName = "";

            // Act
            bool result = UI.NameValidation(emptyName);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void NameValidation_NameTooShort_ReturnsFalse()
        {
            // Arrange
            string shortName = "J";

            // Act
            bool result = UI.NameValidation(shortName);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void NameValidation_NameTooLong_ReturnsFalse()
        {
            // Arrange
            string longName = "ThisIsAReallyLongNameThatExceedsTheMaximumLengthAllowed";

            // Act
            bool result = UI.NameValidation(longName);

            // Assert
            Assert.False(result);
        }
    }
}
