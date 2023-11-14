namespace Username_Validation_UT;

public class Username_Validation_UT
{
    [Fact]
    public void ValidUsername()
    {
        // Test checks if the username "20300674" is valid.
        // The expected result is 01, indicating a valid username.
        string username = "20300674";
        int ACT = UI.UsernameValidation(username);
        int EXP = 01;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void InvalidLength()
    {
        // Test checks if the username "22001001234567890123456789012345678901234567890123456789012345678901234567890"
        // is considered invalid due to its length.
        // The expected result is 10, indicating an invalid length.
        string username = "22001001234567890123456789012345678901234567890123456789012345678901234567890";
        int ACT = UI.UsernameValidation(username);
        int EXP = 10;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void InvalidPeriod()
    {
        // Test checks if the username "22500181" has an invalid period.
        // The expected result is 30, indicating an invalid period.
        string username = "22500181";
        int ACT = UI.UsernameValidation(username);
        int EXP = 30;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void ValidYear()
    {
        // Test checks if the username "20300674" has a valid year.
        // The expected result is 01, indicating a valid username.
        string username = "20300674";
        int ACT = UI.UsernameValidation(username);
        int EXP = 01;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void ValidPeriod()
    {
        // Test checks if the username "20300674" has a valid period.
        // The expected result is 01, indicating a valid username.
        string username = "20300674";
        int ACT = UI.UsernameValidation(username);
        int EXP = 01;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void MinValidLength()
    {
        // Test checks if the username "01300001" meets the minimum valid length.
        // The expected result is 01, indicating a valid username.
        string username = "01300001";
        int ACT = UI.UsernameValidation(username);
        int EXP = 01;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void MaxValidLength()
    {
        // Test checks if the username "99300999" meets the maximum valid length.
        // The expected result is 01, indicating a valid username.
        string username = "99300999";
        int ACT = UI.UsernameValidation(username);
        int EXP = 01;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void ValidYearOnRange()
    {
        // Test checks if the username "99100001" has a valid year within the specified range.
        // The expected result is 01, indicating a valid username.
        string username = "99100001";
        int ACT = UI.UsernameValidation(username);
        int EXP = 01;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void InvalidYearOnRange()
    {
        // Test checks if the username "100300999" has an invalid year within the specified range.
        // The expected result is 10, indicating an invalid year.
        string username = "100300999";
        int ACT = UI.UsernameValidation(username);
        int EXP = 10;
        Assert.Equal(EXP, ACT);
    }

    [Fact]
    public void ValidID()
    {
        // Test checks if the username "22300699" has a valid identifier.
        // The expected result is 01, indicating a valid username.
        string username = "22300699";
        int ACT = UI.UsernameValidation(username);
        int EXP = 01;
        Assert.Equal(EXP, ACT);
    }
}
