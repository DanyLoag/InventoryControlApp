namespace Unit_Test_Validations;

public class UnitTest1
{
    [Fact]
    public void Test_Validation_Time_Succesful_1()
    {
        string Hour="12:00";
        bool ACT=UI.HourValidation(Hour);
        Assert.True(ACT);
    }
    [Fact]
    public void Test_Validation_Time_Succesful_2()
    {
        string Hour="14:00";
        bool ACT=UI.HourValidation(Hour);
        Assert.True(ACT);
    }
    [Fact]
    public void Test_Validation_Time_Succesful_3()
    {
        string Hour="13:40";
        bool ACT=UI.HourValidation(Hour);
        Assert.True(ACT);
    }
    [Fact]
    public void Test_Validation_Time_Succesful_4()
    {
        string Hour="7:00";
        bool ACT=UI.HourValidation(Hour);
        Assert.True(ACT);
    }
    [Fact]
    public void Test_Validation_Time_Succesful_5()
    {
        string Hour="13:59";
        bool ACT=UI.HourValidation(Hour);
        Assert.True(ACT);
    } 

    [Fact]
    public void Test_Validation_Time_UnSuccesful_1()
    {
        string Hour="";
        bool ACT=UI.HourValidation(Hour);
        Assert.False(ACT);
    }
    [Fact]
    public void Test_Validation_Time_UnSuccesful_2()
    {
        string Hour="25:59";
        bool ACT=UI.HourValidation(Hour);
        Assert.False(ACT);
    }

[Fact]
    public void Test_Validation_Time_UnSuccesful_3()
    {
        string Hour="13:-1";
        bool ACT=UI.HourValidation(Hour);
        Assert.False(ACT);
    }

[Fact]
    public void Test_Validation_Time_UnSuccesful_4()
    {
        string Hour="13:74";
        bool ACT=UI.HourValidation(Hour);
        Assert.False(ACT);
    }

[Fact]
    public void Test_Validation_Time_UnSuccesful_5()
    {
        string Hour="13";
        bool ACT=UI.HourValidation(Hour);
        Assert.False(ACT);
    }
[Fact]
public 
void Test_Validation_Date_UnSuccesful_1()
    {
        string Date="15/11/2023";
        bool ACT=UI.DateValidation(Date);
        Assert.False(ACT);
    }
    [Fact]
public 
void Test_Validation_Date_UnSuccesful_2()
    {
        string Date="11/13/2023";
        bool ACT=UI.DateValidation(Date);
        Assert.False(ACT);
    }
    [Fact]
public 
void Test_Validation_Date_UnSuccesful_3()
    {
        string Date="11/18/23";
        bool ACT=UI.DateValidation(Date);
        Assert.False(ACT);
    }
    [Fact]
public 
void Test_Validation_Date_UnSuccesful_4()
    {
        string Date="11152023";
        bool ACT=UI.DateValidation(Date);
        Assert.False(ACT);
    }
    [Fact]
public 
void Test_Validation_Date_UnSuccesful_5()
    {
        string Date="21/11/2023";
        bool ACT=UI.DateValidation(Date);
        Assert.False(ACT);
    }

        [Fact]
public 
void Test_Validation_Date_Succesful_2()
    {
        string Date="11/20/2023";
        bool ACT=UI.DateValidation(Date);
        Assert.True(ACT);
    }
        [Fact]
public 
void Test_Validation_Date_Succesful_3()
    {
        string Date="11/15/2023";
        bool ACT=UI.DateValidation(Date);
        Assert.False(ACT);
    }
        [Fact]
public 
void Test_Validation_Date_Succesful_4()
    {
        string Date="11/17/2023";
        bool ACT=UI.DateValidation(Date);
        Assert.True(ACT);
    }
        [Fact]
public 
void Test_Validation_Date_Succesful_5()
    {
        string Date="11/16/2023";
        bool ACT=UI.DateValidation(Date);
        Assert.True(ACT);
    }




}