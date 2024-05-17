
// using Xunit;
namespace System.Numbers.Tests
{
    public class PrimeServiceTests
    {
        private readonly PrimeService _primeService;

        public PrimeServiceTests()
        {
            _primeService = new PrimeService();
        }

        [Fact]
        public void IsPrime_ReturnsFalse_ForNegativeNumbers()
        {
            // Arrange
            int candidate = -5;

            // Act
            bool result = _primeService.IsPrime(candidate);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsPrime_ReturnsFalse_ForZero()
        {
            // Arrange
            int candidate = 0;

            // Act
            bool result = _primeService.IsPrime(candidate);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsPrime_ReturnsFalse_ForOne()
        {
            // Arrange
            int candidate = 1;

            // Act
            bool result = _primeService.IsPrime(candidate);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsPrime_ReturnsTrue_ForPrimeNumbers()
        {
            // Arrange
            int candidate = 7;

            // Act
            bool result = _primeService.IsPrime(candidate);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPrime_ReturnsFalse_ForNonPrimeNumbers()
        {
            // Arrange
            int candidate = 10;

            // Act
            bool result = _primeService.IsPrime(candidate);

            // Assert
            Assert.False(result);
        }
    }
}