using Xunit;

[Collection("ModNCalculator")]
[Trait("Category", "ModNCalculator")]
public class ModNCalcTest
{
    [Fact]
    public void When_NegativeModulus_Expect_throw()
    {
        var act = () => { var calc = new ModNCalculator(-3); };

        Assert.ThrowsAny<Exception>(act);
    }

    [Fact]
    public void When_Divide_Expect_throw()
    {
        var calc = new ModNCalculator(12);

        var act = () => { _ = calc.Div(1234, 1); };

        Assert.Throws<InvalidOperationException>(act);
    }

    [Theory]
    [InlineData(7, 14, 1, 0)]
    [InlineData(7, 15, 4, 4)]
    [InlineData(7, 1, 15, 1)]
    [InlineData(7, -16, -3, 6)]
    [InlineData(7, -1, 13, 1)]
    public void When_MulAByB_Expect_returnExpectedResult(int modulus, int a, int b, int expectedResult)
    {

        var calc = new ModNCalculator(modulus);

        var res = calc.Mul(a, b);

        Assert.Equal(expectedResult, res);
    }

    [Theory]
    [InlineData(7, 0, 0, 0)]
    [InlineData(7, 15, 0, 1)]
    [InlineData(7, 0, 15, 1)]
    [InlineData(7, -15, 3, 2)]
    [InlineData(7, 2, 3, 5)]
    public void When_AddAandB_Expect_returnExpectedResult(int modulus, int a, int b, int expectedResult)
    {

        var calc = new ModNCalculator(modulus);

        var res = calc.Add(a, b);

        Assert.Equal(expectedResult, res);
    }

}