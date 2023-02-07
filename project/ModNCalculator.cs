
public class ModNCalculator : ICalculator<int>
{
    int n = 10;
    public ModNCalculator(int n)
    {
        if (n <= 1)
        {
            throw new ArgumentOutOfRangeException(nameof(n), n, "value shoud be at least 2");
        }
        this.n = n;
    }
    public int Add(int a, int b) => ((a%n + b%n)%n+n)%n;
    public int Div(int a, int b) => throw new InvalidOperationException("can't divide in Z/nZ");
    public int Mul(int a, int b) => ((a%n * b%n)%n+n)%n;
}