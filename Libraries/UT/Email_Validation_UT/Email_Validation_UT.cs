namespace Email_Validation_UT;

public class Email_Validation_UT
{
    [Fact]
    public void ValidEmail()
    {
        // Test checks if the email "a20300674@ceti.mx" with corresponding registration number 20300674 is valid.
        // The expected result is 01, indicating a valid email.
        string email = "a20300674@ceti.mx";
        long registro = 20300674;
        int ACT = UI.StudentEmailValidation(email, registro);
        int EXP = 01;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void WrongLengthEmail()
    {
        // Test checks if the email "a203006748@ceti.mx" with corresponding registration number 20300674 is invalid due to its length.
        // The expected result is 10, indicating an invalid length.
        string email = "a203006748@ceti.mx";
        long registro = 20300674;
        int ACT = UI.StudentEmailValidation(email, registro);
        int EXP = 10;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void WrongPrefix()
    {
        // Test checks if the email ":V2030067@ceti.mx" with corresponding registration number 20300674 is invalid due to the wrong prefix.
        // The expected result is 20, indicating an invalid prefix.
        string email = ":V2030067@ceti.mx";
        long registro = 20300674;
        int ACT = UI.StudentEmailValidation(email, registro);
        int EXP = 20;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void WrongEmailRegister()
    {
        // Test checks if the email "a20300674@ceti.mx" with corresponding registration number 20300673 is invalid due to mismatched registration numbers.
        // The expected result is 30, indicating an invalid registration number.
        string email = "a20300674@ceti.mx";
        long registro = 20300673;
        int ACT = UI.StudentEmailValidation(email, registro);
        int EXP = 30;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void EmailWithoutCeti()
    {
        // Test checks if the email "a20300674@cetX.mx" with corresponding registration number 20300674 is invalid due to the absence of "@ceti.mx".
        // The expected result is 40, indicating an invalid suffix.
        string email = "a20300674@cetX.mx";
        long registro = 20300674;
        int ACT = UI.StudentEmailValidation(email, registro);
        int EXP = 40;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void ValidLengthInvalidSuffix()
    {
        // Test checks if the email "a203006748@ceti.mx" with corresponding registration number 20300674 is invalid due to the wrong suffix.
        // The expected result is 10, indicating an invalid suffix.
        string email = "a203006748@ceti.mx";
        long registro = 20300674;
        int ACT = UI.StudentEmailValidation(email, registro);
        int EXP = 10;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void ValidLengthAndSuffix()
    {
        // Test checks if the email "a20300674@ceti.mx" with corresponding registration number 20300674 is valid.
        // The expected result is 01, indicating a valid email.
        string email = "a20300674@ceti.mx";
        long registro = 20300674;
        int ACT = UI.StudentEmailValidation(email, registro);
        int EXP = 01;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void ValidSuffixWrongRegister()
    {
        // Test checks if the email "a20300674@ceti.mx" with corresponding registration number 20300673 is invalid due to mismatched registration numbers.
        // The expected result is 30, indicating an invalid registration number.
        string email = "a20300674@ceti.mx";
        long registro = 20300673;
        int ACT = UI.StudentEmailValidation(email, registro);
        int EXP = 30;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void ValidRegisterWrongSuffix()
    {
        // Test checks if the email "a20300674@ceXi.mx" with corresponding registration number 20300674 is invalid due to the wrong suffix.
        // The expected result is 40, indicating an invalid suffix.
        string email = "a20300674@ceXi.mx";
        long registro = 20300674;
        int ACT = UI.StudentEmailValidation(email, registro);
        int EXP = 40;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void InvalidPrefixValidSuffix()
    {
        // Test checks if the email "X20300674@ceti.mx" with corresponding registration number 20300674 is invalid due to the wrong prefix.
        // The expected result is 20, indicating an invalid prefix.
        string email = "X20300674@ceti.mx";
        long registro = 20300674;
        int ACT = UI.StudentEmailValidation(email, registro);
        int EXP = 20;
        Assert.Equal(EXP, ACT);
    }
}
