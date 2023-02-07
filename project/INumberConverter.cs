using System.Numerics;

public interface INumberConverter<T> where T:INumber<T>
{
     T Parse(string value);
     string Stringify(T value);
}