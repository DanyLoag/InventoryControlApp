namespace Password_Unit_Test;

public class UnitTest1
{
    [Fact]
    public void PasswordValidation_ValidPassword_ReturnsZero()
    {
        // Arrange
        string validPassword = "SecureP@ss123";

        // Act
        int result = UI.PasswordValidation(validPassword);

        // Assert
        Assert.Equal(01, result);
    }

    [Fact]


    public void PasswordValidation_ShortPassword_ReturnsTen()
    {
        // Arrange
        string shortPassword = "Short";

        // Act
        int result = UI.PasswordValidation(shortPassword);

        // Assert
        Assert.Equal(10, result);
    }
    [Fact]

    public void PasswordValidation_PasswordWithoutUppercase_ReturnsTwenty()
    {
        // Arrange
        string passwordWithoutUppercase = "lowercase123!";

        // Act
        int result = UI.PasswordValidation(passwordWithoutUppercase);

        // Assert
        Assert.Equal(20, result);
    }
    [Fact]

    public void PasswordValidation_PasswordWithoutDigit_ReturnsThirty()
    {
        // Arrange
        string passwordWithoutDigit = "NoDigits!";

        // Act
        int result = UI.PasswordValidation(passwordWithoutDigit);

        // Assert
        Assert.Equal(30, result);
    }
    [Fact]

    public void PasswordValidation_PasswordWithoutSpecialCharacter_ReturnsForty()
    {
        // Arrange
        string passwordWithoutSpecialChar = "NoSpecialChar123";

        // Act
        int result = UI.PasswordValidation(passwordWithoutSpecialChar);

        // Assert
        Assert.Equal(40, result);
    }
}