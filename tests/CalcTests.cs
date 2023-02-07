using Xunit;

public class CalcTest
{

    [Fact]
    public void DivdeBy0_should_throw()
    {
        var calc = new Calculator();

        var act = () => { _=calc.Div(1234,0); };

        Assert.Throws<DivideByZeroException>(act);
    }

    [Theory]
    [InlineData(14,1,14)]
    [InlineData(15,4,60)]
    [InlineData(1,15,15)]
    [InlineData(-16,-3,48)]
    [InlineData(-1,14,-14)]
    public void MulAByB_should_returnExpectedResult(int a, int b, int expectedResult){

        var calc = new Calculator();

        var res = calc.Mul(a,b);

        Assert.Equal(expectedResult, res);
    }

    [Theory]
    [InlineData(14,1,14)]
    [InlineData(15,4,3)]
    [InlineData(75,15,5)]
    [InlineData(-16,3,-5)]
    [InlineData(-1,-1,1)]
    public void DivAByB_should_returnExpectedResult(int a, int b, int expectedResult){

        var calc = new Calculator();

        var res = calc.Div(a,b);

        Assert.Equal(expectedResult, res);
    }


    [Theory]
    [InlineData(0,0,0)]
    [InlineData(15,0,15)]
    [InlineData(0,15,15)]
    [InlineData(-15,3,-12)]
    [InlineData(2,3,5)]
    public void AddAandB_should_returnExpectedResult(int a, int b, int expectedResult){

        var calc = new Calculator();

        var res = calc.Add(a,b);

        Assert.Equal(expectedResult, res);
    }

}