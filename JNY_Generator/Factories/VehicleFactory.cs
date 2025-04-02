using JNY_Generator.Enums;
using JNY_Generator.Vehicles;

namespace JNY_Generator.Factories
{
    public static class VehicleFactory
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// Creates a new instance of a <see cref="CarViewModel"> with randomized properties.
        /// </summary>
        /// <returns>A new <see cref="CarViewModel"> instance with randomized properties.</returns>
        public static CarViewModel CreateRandomCarViewModel()
        {
            return new CarViewModel
            {
                Identifier = GenerateRandomString(10),
                Descriptor = GenerateRandomString(20),
                Weight = GenerateRandomDouble(1000, 10000),
                Width = GenerateRandomDouble(5, 10),
                Height = GenerateRandomDouble(4, 8),
                Length = GenerateRandomDouble(10, 20),
                Manufacturer = GenerateRandomString(15),
                ModelYear = (uint)GenerateRandomInt(1900, 2025),
                BodyStyle = (BodyStyleEnum)_random.Next(Enum.GetValues(typeof(BodyStyleEnum)).Length),
                Fuel = (FuelEnum)_random.Next(Enum.GetValues(typeof(FuelEnum)).Length),
            };
        }

        /// <summary>
        /// Creates a new instance of a <see cref="BoatViewModel"> with randomized properties.
        /// </summary>
        /// <returns>A new <see cref="BoatViewModel"> instance with randomized properties.</returns>
        public static BoatViewModel CreateRandomBoatViewModel()
        {
            return new BoatViewModel
            {
                Identifier = GenerateRandomString(10),
                Descriptor = GenerateRandomString(20),
                Weight = GenerateRandomDouble(1000, 1000000),
                Width = GenerateRandomDouble(5, 500),
                Height = GenerateRandomDouble(4, 300),
                Length = GenerateRandomDouble(10, 1500),
                Power = (PowerEnum)_random.Next(Enum.GetValues(typeof(PowerEnum)).Length),
                Draft = GenerateRandomDouble(1, 50),
                Manufacturer = GenerateRandomString(15)
            };
        }

        /// <summary>
        /// Generates a random string of the specified length. The string will contain only alphanumeric characters and
        /// spaces.
        /// </summary>
        /// <param name="length">The length of the random string to generate.</param>
        /// <returns>A random string of the specified length.</returns>
        private static string GenerateRandomString(int length)
        {
            const string chars = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                                        .Select(s => s[_random.Next(s.Length)])
                                        .ToArray());
        }

        /// <summary>
        /// Generates a random double value within the specified range, limited to two decimal places.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned.</param>
        /// <returns>A random double value within the specified range.</returns>
        private static double GenerateRandomDouble(double minValue, double maxValue)
        {
            return Math.Round(_random.NextDouble() * (maxValue - minValue) + minValue, 2);
        }

        /// <summary>
        /// Generates a random integer value within the specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned.</param>
        /// <returns>A random integer value within the specified range.</returns>
        private static int GenerateRandomInt(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }
}
