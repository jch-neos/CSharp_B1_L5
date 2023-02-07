public class MicroCalc{
    private readonly ICalculator<int> calculator;
    private readonly INumberConverter<int> converter;

    public MicroCalc(ICalculator<int> calculator, INumberConverter<int> converter)
    {
        this.calculator = calculator;
        this.converter = converter;
    }

    public string Add(string a,string b)
    {
        var (valueA, valueB) = Parse(a, b);
        int value = calculator.Add(valueA, valueB);
        return converter.Stringify(value);
    }

    private (int,int) Parse(string a, string b)
    {
        int valueA = converter.Parse(a);
        int valueB = converter.Parse(b);
        return (valueA,valueB);
    }

    public string Minus(string a,string b){
        var (valueA, valueB) = Parse(a, b);
        int value = calculator.Add(valueA, -valueB);
        return converter.Stringify(value);
    }

    public string Mul(string a,string b){
        var (valueA, valueB) = Parse(a, b);
        int value = calculator.Mul(valueA, valueB);
        return converter.Stringify(value);
    }

}