import math

class PrimeService:
    def is_prime(self, candidate):
        if candidate < 2:
            return False

        for divisor in range(2, int(math.sqrt(candidate)) + 1):
            if candidate % divisor == 0:
                return False

        return True

if __name__ == "__main__":
    prime_service = PrimeService()

    # Example usage
    test_numbers = [1, 2, 3, 4, 5, 16, 17, 18, 19, 20]
    for number in test_numbers:
        print(f"{number} is prime: {prime_service.is_prime(number)}") 