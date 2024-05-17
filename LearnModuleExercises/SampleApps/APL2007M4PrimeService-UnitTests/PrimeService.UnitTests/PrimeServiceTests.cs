namespace System.Numbers.UnitTests;

public class PrimeServiceTests
{
    private readonly PrimeService _primeService;

    public PrimeServiceTests()
    {
        _primeService = new PrimeService();
    }
    
    [Fact]
    public void IsPrime_InputIs1_ReturnFalse()
    {
        var result = _primeService.IsPrime(1);
        Assert.False(result, "1 should not be prime");
    }

    [Fact]
    public void IsPrime_InputIs2_ReturnTrue()
    {
        var result = _primeService.IsPrime(2);
        Assert.True(result, "2 should be prime");
    }

    [Fact]
    public void IsPrime_InputIs3_ReturnTrue()
    {
        var result = _primeService.IsPrime(3);
        Assert.True(result, "3 should be prime");
    }

    [Fact]
    public void IsPrime_InputIs4_ReturnFalse()
    {
        var result = _primeService.IsPrime(4);
        Assert.False(result, "4 should not be prime");
    }
    
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    public void IsPrime_NegativeNumbersAndZero_ReturnFalse(int value)
    {
        var result = _primeService.IsPrime(value);
        Assert.False(result, $"{value} should not be prime");
    }
}
