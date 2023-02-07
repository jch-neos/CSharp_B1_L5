using Moq;
using Xunit;

public class MicroCalcTheorys
{
    private MicroCalc _microCalc;
    private Mock<ICalculator<int>> _mockCalculator;
    private Mock<INumberConverter<int>> _mockConverter;

    void SetUp()
    {
        _mockCalculator = new Mock<ICalculator<int>>();
        _mockConverter = new Mock<INumberConverter<int>>();
        _microCalc = new MicroCalc(_mockCalculator.Object, _mockConverter.Object);
    }

    [Theory]
    [InlineData(1,2,3)]
    public void Add_ReturnsExpectedResult(int a, int b, int expectedResult)
    {
        // Arrange
        SetUp();
        _mockCalculator.Setup(x => x.Add(a, b))
            .Returns(expectedResult);
        _mockConverter.Setup(x => x.Parse(It.Is(a.ToString(),StringComparer.Ordinal)))
            .Returns(a);
        _mockConverter.Setup(x => x.Parse(It.Is(b.ToString(),StringComparer.Ordinal)))
            .Returns(b);
        _mockConverter.Setup(x => x.Stringify(expectedResult))
            .Returns(expectedResult.ToString());

        // Act
        string result = _microCalc.Add(a.ToString(), b.ToString());

        // Assert
        Assert.Equal(expectedResult.ToString(), result);
    }

    [Theory]
    [InlineData(1,2,-1)]
    public void Minus_ReturnsExpectedResult(int a, int b, int expectedResult)
    {
        // Arrange
        SetUp();
        _mockCalculator.Setup(x => x.Add(a,-b))
            .Returns(expectedResult);
        _mockConverter.Setup(x => x.Parse(It.Is(a.ToString(),StringComparer.Ordinal)))
            .Returns(a);
        _mockConverter.Setup(x => x.Parse(It.Is(b.ToString(),StringComparer.Ordinal)))
            .Returns(b);

        _mockConverter.Setup(x => x.Stringify(expectedResult))
            .Returns(expectedResult.ToString());

        // Act
        string result = _microCalc.Minus(a.ToString(), b.ToString());

        // Assert
        Assert.Equal(expectedResult.ToString(), result);
    }

    [Theory]
    [InlineData(2,2,4)]
    public void Mul_ReturnsExpectedResult(int a, int b, int expectedResult)
    {
        // Arrange
        SetUp();
        _mockCalculator.Setup(x => x.Mul(a, b))
            .Returns(expectedResult);
        _mockConverter.Setup(x => x.Parse(It.Is(a.ToString(),StringComparer.Ordinal)))
            .Returns(a);
        _mockConverter.Setup(x => x.Parse(It.Is(b.ToString(),StringComparer.Ordinal)))
            .Returns(b);
        _mockConverter.Setup(x => x.Stringify(expectedResult))
            .Returns(expectedResult.ToString());

        // Act
        string result = _microCalc.Mul(a.ToString(), b.ToString());

        // Assert
        Assert.Equal(expectedResult.ToString(), result);
    }
}