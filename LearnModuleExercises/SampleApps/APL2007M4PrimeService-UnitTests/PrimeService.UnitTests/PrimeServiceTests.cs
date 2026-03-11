namespace System.Numbers.UnitTests
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
        public void IsPrime_ReturnsFalse_ForEvenNumbersGreaterThanTwo()
        {
            // Arrange
            int candidate = 4;
        
            // Act
            bool result = _primeService.IsPrime(candidate);
        
            // Assert
            Assert.False(result);
        }        [Fact]
        public void IsPrime_ReturnsTrue_ForLargePrimeNumbers()
        {
            // Arrange
            int candidate = 7919; // 7919 is a prime number
        
            // Act
            bool result = _primeService.IsPrime(candidate);
        
            // Assert
            Assert.True(result);
        }        [Fact]
        public void IsPrime_ReturnsFalse_ForLargeNonPrimeNumbers()
        {
            // Arrange
            int candidate = 8000; // 8000 is not a prime number
        
            // Act
            bool result = _primeService.IsPrime(candidate);
        
            // Assert
            Assert.False(result);
        }        [Fact]
        public void IsPrime_ReturnsTrue_ForTwo()
        {
            // Arrange
            int candidate = 2;
        
            // Act
            bool result = _primeService.IsPrime(candidate);
        
            // Assert
            Assert.True(result);
        }
    }
}