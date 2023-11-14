namespace Register_Validation_UT;

public class Register_Validation_UT
{
    [Fact]
    public void ValidRegister()
    {
        // Test checks if the registration number 20300682 is valid.
        // The expected result is 01, indicating a valid registration.
        int registro = 20300682;
        int ACT = UI.RegisterValidation(registro);
        int EXP = 01;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void InvalidLength()
    {
        // Test checks if the registration number 203006822 is invalid due to its length.
        // The expected result is 10, indicating an invalid length.
        int registro = 203006822;
        int ACT = UI.RegisterValidation(registro);
        int EXP = 10;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void InvalidYear()
    {
        // Test checks if the registration number 24300682 is invalid due to the year exceeding the current year.
        // The expected result is 20, indicating an invalid year.
        int registro = 24300682;
        int ACT = UI.RegisterValidation(registro);
        int EXP = 20;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void ValidPeriodAndYear()
    {
        // Test checks if the registration number 22300682 has a valid period and year.
        // The expected result is 01, indicating a valid registration.
        int registro = 22300682;
        int ACT = UI.RegisterValidation(registro);
        int EXP = 01;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void InvalidPeriodAndYear()
    {
        // Test checks if the registration number 25500682 has an invalid period and year.
        // The expected result is 20, indicating an invalid period and year.
        int registro = 25500682;
        int ACT = UI.RegisterValidation(registro);
        int EXP = 20;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void ValidYearPeriodAndLength()
    {
        // Test checks if the registration number 23100200 has a valid year, period, and length.
        // The expected result is 01, indicating a valid registration.
        int registro = 23100200;
        int ACT = UI.RegisterValidation(registro);
        int EXP = 01;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void InvalidYearPeriodAndLength()
    {
        // Test checks if the registration number 255006820 has an invalid year, period, and length.
        // The expected result is 10, indicating an invalid length.
        int registro = 255006820;
        int ACT = UI.RegisterValidation(registro);
        int EXP = 10;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void InvalidLengthValidYearAndPeriod()
    {
        // Test checks if the registration number 223006999 has an invalid length.
        // The expected result is 10, indicating an invalid length.
        int registro = 223006999;
        int ACT = UI.RegisterValidation(registro);
        int EXP = 10;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void ValidLengthInvalidYear()
    {
        // Test checks if the registration number 99300674 is valid.
        // The expected result is 20, indicating an invalid year.
        int registro = 99300674;
        int ACT = UI.RegisterValidation(registro);
        int EXP = 20;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void ValidYearInvalidPeriod()
    {
        // Test checks if the registration number 23600588 has an invalid period.
        // The expected result is 30, indicating an invalid period.
        int registro = 23600588;
        int ACT = UI.RegisterValidation(registro);
        int EXP = 30;
        Assert.Equal(EXP, ACT);
    }
}
