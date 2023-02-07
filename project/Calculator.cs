using System.Numerics;

public interface ICalculator<T> where T: INumber<T>
{
    T Add(T a, T b);
    T Div(T a, T b);
    T Mul(T a, T b);
}

public class Calculator : ICalculator<int>
{
    public Calculator() { }
    public int Add(int a, int b) => a + b;
    public int Div(int a, int b) => a / b;
    public int Mul(int a, int b) => a * b;
}
