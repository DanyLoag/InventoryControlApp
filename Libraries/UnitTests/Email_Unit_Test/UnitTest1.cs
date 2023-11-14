namespace Email_Unit_Test;

public class UnitTest1
{
    [Fact]
    public void EmailValidation_ValidEmail1_ReturnsTrue()
    {
        // Arrange
        string validEmail = "john.doe@ceti.mx";

        // Act
        bool result = UI.EmailValidation(validEmail);

        // Assert
        Assert.True(result);
    }
    [Fact]

    public void EmailValidation_ValidEmail2_ReturnsTrue()
    {
        // Arrange
        string validEmail = "john.doe@live.ceti.mx";

        // Act
        bool result = UI.EmailValidation(validEmail);

        // Assert
        Assert.True(result);
    }
    [Fact]

    public void EmailValidation_InvalidEmail_ReturnsFalse()
    {
        // Arrange
        string invalidEmail = "john.doe@gmail.com";

        // Act
        bool result = UI.EmailValidation(invalidEmail);

        // Assert
        Assert.False(result);
    }
}