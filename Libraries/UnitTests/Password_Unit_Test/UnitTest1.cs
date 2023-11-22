namespace Password_Unit_Test;

public class UnitTest1
{
    [Fact]
    public void PasswordValidation_ValidPassword_ReturnsZero()
    {
        // Arrange
        string validPassword = "3hfyT4)#f.nlJ";

        // Act
        int result = UI.PasswordValidation(validPassword);

        // Assert
        Assert.Equal(1, result);
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
        string passwordWithoutUppercase = "lower&case6980#";

        // Act
        int result = UI.PasswordValidation(passwordWithoutUppercase);

        // Assert
        Assert.Equal(20, result);
    }
    [Fact]

    public void PasswordValidation_PasswordWithoutDigit_ReturnsThirty()
    {
        // Arrange
        string passwordWithoutDigit = "NoDigits!@";

        // Act
        int result = UI.PasswordValidation(passwordWithoutDigit);

        // Assert
        Assert.Equal(30, result);
    }
    [Fact]

    public void PasswordValidation_PasswordWithoutSpecialCharacter_ReturnsForty()
    {
        // Arrange
        string passwordWithoutSpecialChar = "NoSpecialChar12365";

        // Act
        int result = UI.PasswordValidation(passwordWithoutSpecialChar);

        // Assert
        Assert.Equal(40, result);
    }

    
    [Fact]
    public void PasswordValidation_PasswordWithoutLowercase_Returns20()
    {
        // Arrange
        string passwordWithoutLowercase = "uppercase123&#!";

        // Act
        int result = UI.PasswordValidation(passwordWithoutLowercase);

        // Assert
        Assert.Equal(20, result);
    }

    [Fact]
    public void PasswordValidation_PasswordWithoutAlphanumeric_ReturnsSeventy()
    {
        // Arrange
        string passwordWithoutAlphanumeric = "!@#$%^&*()-_+=<>?";

        // Act
        int result = UI.PasswordValidation(passwordWithoutAlphanumeric);

        // Assert
        Assert.Equal(20, result);
    }

    [Fact]
    public void PasswordValidation_CommonPassword_ReturnsEighty()
    {
        // Arrange
        string commonPassword = "contraseña";

        // Act
        int result = UI.PasswordValidation(commonPassword);

        // Assert
        Assert.Equal(20, result);
    }

    [Fact]
    public void PasswordValidation_PasswordWithoutNonAlphanumeric_ReturnsNinety()
    {
        // Arrange
        string passwordWithoutNonAlphanumeric = "AlphanumericOnly123";

        // Act
        int result = UI.PasswordValidation(passwordWithoutNonAlphanumeric);

        // Assert
        Assert.Equal(40, result);
    }

    [Fact]
    public void PasswordValidation_PasswordWithoutUppercaseOrLowercase_ReturnsOneHundred()
    {
        // Arrange
        string passwordWithoutUppercaseOrLowercase = "123456!890";

        // Act
        int result = UI.PasswordValidation(passwordWithoutUppercaseOrLowercase);

        // Assert
        Assert.Equal(20, result);
    }
}