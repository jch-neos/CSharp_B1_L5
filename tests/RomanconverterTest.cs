using Xunit;

public class RomanNumeralConverterTest{
    public RomanNumeralConverterTest(){

    }
    [Fact]
    public void When_emptyString_expect_throw(){
        RomanNumeralConverter converter = new();
        var action = () => { _=converter.Parse(String.Empty); };
        // var exception=Assert.ThrowsAny<ArgumentException>(action);
        // Assert.Contains("value", exception.Message);
        action.Should().Throw<ArgumentException>().WithMessage("*value*");
    }
    
    [Theory]
    [InlineData("AXI")]
    [InlineData("IXXIIX")]
    [InlineData("NI")]
    [InlineData("XXIVI")]
    [InlineData("23")]
    [InlineData(" ")]
    public void When_InvalidNumeral_expect_throw(string num){
        RomanNumeralConverter converter = new();
        var action = () => { _=converter.Parse(num); };
        action.Should().Throw<FormatException>();
    }
    [Theory]
    [InlineData("IVIV")]
    public void When_InvalidNumeral_expect_throwRepeatedGroup(string num){
        RomanNumeralConverter converter = new();
        var action = () => { _=converter.Parse(num); };
        action.Should().Throw<FormatException>().WithMessage("*2 groups*");
    }

    [Theory]
    [InlineData("XI",11)]
    [InlineData("XXIV",24)]
    [InlineData("IV",4)]
    [InlineData("N",0)]
    [InlineData("CDXLIV",444)]
    [InlineData("V",5)]
    public void When_ValidNumeral_expect_returnCorrectValue(string num, int expected){
        RomanNumeralConverter converter = new();
        var value =converter.Parse(num);
        value.Should().Be(expected);
    }

   [Theory]
    [InlineData(11,"XI")]
    [InlineData(24,"XXIV")]
    [InlineData(4,"IV")]
    [InlineData(0,"N")]
    [InlineData(444,"CDXLIV")]
    [InlineData(5,"V")]
    public void When_PositiveValue_expect_returnCorrectNuvmeral(int num, string expected){
        RomanNumeralConverter converter = new();
        var value =converter.Stringify(num);
        value.Should().Be(expected);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-101)]
    public void When_NegativeValue_expect_throw(int num) {
        RomanNumeralConverter converter = new();
        var action = () => { _=converter.Stringify(num); };
        action.Should().Throw<ArgumentException>();
    }
}