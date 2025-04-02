using System.Windows.Media.Imaging;
using JNY_Generator.Enums;
using JNY_Generator.Vehicles;

namespace JNY_Generator.Factories
{
    public static class VehicleFactory
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// Static array of car make, model, body style, and fuel tuples.
        /// </summary>
        private static readonly (string Make, string Model, BodyStyleEnum BodyStyle, FuelEnum Fuel)[] CarSpecifications =
        [
            ("Toyota", "Camry", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Toyota", "Corolla", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Toyota", "Prius", BodyStyleEnum.CROSSOVER, FuelEnum.HYBRID),
            ("Toyota", "Highlander", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Toyota", "RAV4", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Honda", "Civic", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Honda", "Accord", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Honda", "CR-V", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Honda", "Pilot", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Honda", "Fit", BodyStyleEnum.CROSSOVER, FuelEnum.REGULAR),
            ("Ford", "Mustang", BodyStyleEnum.COUPE, FuelEnum.REGULAR),
            ("Ford", "F-150", BodyStyleEnum.TRUCK, FuelEnum.REGULAR),
            ("Ford", "Explorer", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Ford", "Escape", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Ford", "Fusion", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Chevrolet", "Impala", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Chevrolet", "Malibu", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Chevrolet", "Equinox", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Chevrolet", "Tahoe", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Chevrolet", "Silverado", BodyStyleEnum.TRUCK, FuelEnum.REGULAR),
            ("Nissan", "Altima", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Nissan", "Sentra", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Nissan", "Maxima", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Nissan", "Rogue", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Nissan", "Murano", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("BMW", "3 Series", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("BMW", "5 Series", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("BMW", "7 Series", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("BMW", "X3", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("BMW", "X5", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Mercedes-Benz", "C-Class", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Mercedes-Benz", "E-Class", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Mercedes-Benz", "S-Class", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Mercedes-Benz", "GLC", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Mercedes-Benz", "GLE", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Audi", "A4", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Audi", "A6", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Audi", "A8", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Audi", "Q5", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Audi", "Q7", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Volkswagen", "Passat", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Volkswagen", "Jetta", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Volkswagen", "Golf", BodyStyleEnum.CROSSOVER, FuelEnum.REGULAR),
            ("Volkswagen", "Tiguan", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Volkswagen", "Atlas", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Hyundai", "Elantra", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Hyundai", "Sonata", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Hyundai", "Tucson", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Hyundai", "Santa Fe", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Hyundai", "Palisade", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Kia", "Optima", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Kia", "Sorento", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Kia", "Sportage", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Kia", "Soul", BodyStyleEnum.CROSSOVER, FuelEnum.REGULAR),
            ("Kia", "Telluride", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Subaru", "Outback", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Subaru", "Forester", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Subaru", "Impreza", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Subaru", "Crosstrek", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Subaru", "Ascent", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Mazda", "3", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Mazda", "6", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Mazda", "CX-5", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Mazda", "CX-9", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Mazda", "MX-5 Miata", BodyStyleEnum.SPORTS, FuelEnum.REGULAR),
            ("Lexus", "ES", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Lexus", "RX", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Lexus", "NX", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Lexus", "GX", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Lexus", "LS", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Acura", "TLX", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Acura", "RDX", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Acura", "MDX", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Acura", "ILX", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Acura", "NSX", BodyStyleEnum.SPORTS, FuelEnum.REGULAR),
            ("Infiniti", "Q50", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Infiniti", "Q60", BodyStyleEnum.COUPE, FuelEnum.REGULAR),
            ("Infiniti", "QX50", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Infiniti", "QX60", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Infiniti", "QX80", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Cadillac", "CT5", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Cadillac", "XT5", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Cadillac", "Escalade", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Cadillac", "CT4", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Cadillac", "XT4", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Lincoln", "MKZ", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Lincoln", "Nautilus", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Lincoln", "Aviator", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Lincoln", "Navigator", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Lincoln", "Corsair", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Volvo", "S60", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Volvo", "S90", BodyStyleEnum.SEDAN, FuelEnum.REGULAR),
            ("Volvo", "XC40", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Volvo", "XC60", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Volvo", "XC90", BodyStyleEnum.SUV, FuelEnum.REGULAR),
            ("Tesla", "Model S", BodyStyleEnum.SEDAN, FuelEnum.ELECTRIC),
            ("Tesla", "Model 3", BodyStyleEnum.SEDAN, FuelEnum.ELECTRIC),
            ("Tesla", "Model X", BodyStyleEnum.SUV, FuelEnum.ELECTRIC),
            ("Tesla", "Model Y", BodyStyleEnum.SUV, FuelEnum.ELECTRIC),
            ("Chevrolet", "Bolt", BodyStyleEnum.CROSSOVER, FuelEnum.ELECTRIC),
            ("Nissan", "Leaf", BodyStyleEnum.CROSSOVER, FuelEnum.ELECTRIC),
            ("BMW", "i3", BodyStyleEnum.CROSSOVER, FuelEnum.ELECTRIC),
            ("Hyundai", "Kona Electric", BodyStyleEnum.SUV, FuelEnum.ELECTRIC),
            ("Kia", "Niro EV", BodyStyleEnum.SUV, FuelEnum.ELECTRIC),
            ("Ford", "F-150 Lightning", BodyStyleEnum.TRUCK, FuelEnum.ELECTRIC),
            ("Rivian", "R1T", BodyStyleEnum.TRUCK, FuelEnum.ELECTRIC),
            ("Lucid", "Air", BodyStyleEnum.SEDAN, FuelEnum.ELECTRIC),
            ("Porsche", "Taycan", BodyStyleEnum.SEDAN, FuelEnum.ELECTRIC),
            ("Audi", "e-tron", BodyStyleEnum.SUV, FuelEnum.ELECTRIC),
            ("Jaguar", "I-Pace", BodyStyleEnum.SUV, FuelEnum.ELECTRIC),
            ("Mercedes-Benz", "EQC", BodyStyleEnum.SUV, FuelEnum.ELECTRIC),
            ("Volkswagen", "ID.4", BodyStyleEnum.SUV, FuelEnum.ELECTRIC),
            ("Volvo", "XC40 Recharge", BodyStyleEnum.SUV, FuelEnum.ELECTRIC),
            ("Polestar", "2", BodyStyleEnum.SEDAN, FuelEnum.ELECTRIC),
            ("Hyundai", "Ioniq 5", BodyStyleEnum.SUV, FuelEnum.ELECTRIC),
            ("Kia", "EV6", BodyStyleEnum.SUV, FuelEnum.ELECTRIC),
            ("Chevrolet", "Volt", BodyStyleEnum.SEDAN, FuelEnum.HYBRID),
            ("Toyota", "Camry Hybrid", BodyStyleEnum.SEDAN, FuelEnum.HYBRID),
            ("Honda", "Accord Hybrid", BodyStyleEnum.SEDAN, FuelEnum.HYBRID),
            ("Ford", "Fusion Hybrid", BodyStyleEnum.SEDAN, FuelEnum.HYBRID),
            ("Hyundai", "Sonata Hybrid", BodyStyleEnum.SEDAN, FuelEnum.HYBRID),
            ("Kia", "Optima Hybrid", BodyStyleEnum.SEDAN, FuelEnum.HYBRID),
            ("Lexus", "ES Hybrid", BodyStyleEnum.SEDAN, FuelEnum.HYBRID),
            ("Toyota", "Highlander Hybrid", BodyStyleEnum.SUV, FuelEnum.HYBRID),
            ("Ford", "Escape Hybrid", BodyStyleEnum.SUV, FuelEnum.HYBRID),
            ("Honda", "CR-V Hybrid", BodyStyleEnum.SUV, FuelEnum.HYBRID),
            ("Hyundai", "Tucson Hybrid", BodyStyleEnum.SUV, FuelEnum.HYBRID),
            ("Kia", "Sorento Hybrid", BodyStyleEnum.SUV, FuelEnum.HYBRID),
            ("Lexus", "RX Hybrid", BodyStyleEnum.SUV, FuelEnum.HYBRID),
            ("Toyota", "RAV4 Hybrid", BodyStyleEnum.SUV, FuelEnum.HYBRID),
            ("Ford", "Explorer Hybrid", BodyStyleEnum.SUV, FuelEnum.HYBRID),
            ("Honda", "Pilot Hybrid", BodyStyleEnum.SUV, FuelEnum.HYBRID),
            ("Hyundai", "Santa Fe Hybrid", BodyStyleEnum.SUV, FuelEnum.HYBRID),
            ("Kia", "Telluride Hybrid", BodyStyleEnum.SUV, FuelEnum.HYBRID),
            ("Lexus", "NX Hybrid", BodyStyleEnum.SUV, FuelEnum.HYBRID),
            ("Toyota", "Sienna", BodyStyleEnum.MINIVAN, FuelEnum.HYBRID),
            ("Chrysler", "Pacifica Hybrid", BodyStyleEnum.MINIVAN, FuelEnum.HYBRID),
            ("Honda", "Odyssey", BodyStyleEnum.MINIVAN, FuelEnum.REGULAR),
            ("Kia", "Carnival", BodyStyleEnum.MINIVAN, FuelEnum.REGULAR),
            ("Mercedes-Benz", "Sprinter", BodyStyleEnum.VAN, FuelEnum.DIESEL),
            ("Ford", "Transit", BodyStyleEnum.VAN, FuelEnum.DIESEL),
            ("Ram", "ProMaster", BodyStyleEnum.VAN, FuelEnum.DIESEL),
            ("Chevrolet", "Express", BodyStyleEnum.VAN, FuelEnum.DIESEL),
            ("Nissan", "NV", BodyStyleEnum.VAN, FuelEnum.DIESEL),
            ("Freightliner", "Cascadia", BodyStyleEnum.SEMI, FuelEnum.DIESEL),
            ("Volvo", "VNL", BodyStyleEnum.SEMI, FuelEnum.DIESEL),
            ("Kenworth", "T680", BodyStyleEnum.SEMI, FuelEnum.DIESEL),
            ("Peterbilt", "579", BodyStyleEnum.SEMI, FuelEnum.DIESEL),
            ("Mack", "Anthem", BodyStyleEnum.SEMI, FuelEnum.DIESEL)
        ];

        /// <summary>
        /// Static array of boat manufacturers, types, and power tuples.
        /// </summary>
        private static readonly (string Manufacturer, string Type, PowerEnum Power)[] BoatSpecifications =
        [
            ("Yamaha", "242X", PowerEnum.MOTOR),
            ("Bayliner", "Element E18", PowerEnum.MOTOR),
            ("Sea Ray", "SPX 190", PowerEnum.MOTOR),
            ("Boston Whaler", "Montauk 170", PowerEnum.MOTOR),
            ("Chaparral", "H2O 19", PowerEnum.MOTOR),
            ("Crestliner", "1650 Discovery", PowerEnum.MOTOR),
            ("Lund", "1775 Adventure", PowerEnum.MOTOR),
            ("Tracker", "Pro Team 175", PowerEnum.MOTOR),
            ("Ranger", "RT188", PowerEnum.MOTOR),
            ("Nitro", "Z18", PowerEnum.MOTOR),
            ("MasterCraft", "XT23", PowerEnum.MOTOR),
            ("Malibu", "Wakesetter 23 LSV", PowerEnum.MOTOR),
            ("Tige", "RZX3", PowerEnum.MOTOR),
            ("Axis", "A24", PowerEnum.MOTOR),
            ("Centurion", "Ri237", PowerEnum.MOTOR),
            ("Supra", "SA 550", PowerEnum.MOTOR),
            ("Moomba", "Craz", PowerEnum.MOTOR),
            ("Nautique", "Super Air G23", PowerEnum.MOTOR),
            ("Correct Craft", "Ski Nautique", PowerEnum.MOTOR),
            ("Triton", "20 TRX", PowerEnum.MOTOR),
            ("Skeeter", "FXR21", PowerEnum.MOTOR),
            ("Phoenix", "921 Elite", PowerEnum.MOTOR),
            ("Caymas", "CX 21", PowerEnum.MOTOR),
            ("Vexus", "VX20", PowerEnum.MOTOR),
            ("Xpress", "X19", PowerEnum.MOTOR),
            ("G3", "Sportsman 1910", PowerEnum.MOTOR),
            ("Alumacraft", "Competitor 185", PowerEnum.MOTOR),
            ("Smoker Craft", "Pro Angler 182", PowerEnum.MOTOR),
            ("Starcraft", "SVX 171", PowerEnum.MOTOR),
            ("Hurricane", "SunDeck 187", PowerEnum.MOTOR),
            ("Godfrey", "Sweetwater 2286", PowerEnum.MOTOR),
            ("Bennington", "22 SSRX", PowerEnum.MOTOR),
            ("Harris", "Cruiser 210", PowerEnum.MOTOR),
            ("Sylvan", "Mirage 8522", PowerEnum.MOTOR),
            ("Sun Tracker", "Party Barge 22", PowerEnum.MOTOR),
            ("Avalon", "LSZ 2285", PowerEnum.MOTOR),
            ("Manitou", "Aurora LE 22", PowerEnum.MOTOR),
            ("Premier", "220 SunSation", PowerEnum.MOTOR),
            ("South Bay", "222RS", PowerEnum.MOTOR),
            ("Barletta", "C22UC", PowerEnum.MOTOR),
            ("Princecraft", "Vectra 23", PowerEnum.MOTOR),
            ("Tahoe", "1950", PowerEnum.MOTOR),
            ("Regal", "LS2", PowerEnum.MOTOR),
            ("Cobalt", "CS23", PowerEnum.MOTOR),
            ("Four Winns", "HD 200", PowerEnum.MOTOR),
            ("Glastron", "GT 205", PowerEnum.MOTOR),
            ("Monterey", "M-22", PowerEnum.MOTOR),
            ("Rinker", "Q3 OB", PowerEnum.MOTOR),
            ("Stingray", "192SC", PowerEnum.MOTOR),
            ("Crownline", "E 205 XS", PowerEnum.MOTOR),
            ("Beneteau", "Oceanis 38.1", PowerEnum.SAIL),
            ("Jeanneau", "Sun Odyssey 349", PowerEnum.SAIL),
            ("Catalina", "425", PowerEnum.SAIL),
            ("Hunter", "Marlow-Hunter 31", PowerEnum.SAIL),
            ("Dufour", "360 Grand Large", PowerEnum.SAIL),
            ("Hanse", "388", PowerEnum.SAIL),
            ("Bavaria", "C42", PowerEnum.SAIL),
            ("Lagoon", "42", PowerEnum.SAIL),
            ("Leopard", "45", PowerEnum.SAIL),
            ("Fountaine Pajot", "Elba 45", PowerEnum.SAIL),
            ("Hobie", "Mirage Pro Angler 14", PowerEnum.UNPOWERED),
            ("Old Town", "Sportsman 106", PowerEnum.UNPOWERED),
            ("Perception", "Pescador Pro 12", PowerEnum.UNPOWERED),
            ("Wilderness Systems", "Tarpon 120", PowerEnum.UNPOWERED),
            ("Pelican", "Catch 120", PowerEnum.UNPOWERED),
            ("Vibe", "Sea Ghost 130", PowerEnum.UNPOWERED),
            ("Ocean Kayak", "Malibu Two", PowerEnum.UNPOWERED),
            ("Sun Dolphin", "Aruba 10", PowerEnum.UNPOWERED),
            ("Lifetime", "Tamarack Angler 100", PowerEnum.UNPOWERED),
            ("Emotion", "Spitfire 9", PowerEnum.UNPOWERED)
        ];

        /// <summary>
        /// Creates a new instance of a <see cref="CarViewModel"/> with randomized properties.
        /// </summary>
        /// <returns>A new <see cref="CarViewModel"/> instance with randomized properties.</returns>
        public static CarViewModel CreateRandomCarViewModel()
        {
            var (make, model, bodyStyle, fuel) = CarSpecifications[_random.Next(CarSpecifications.Length)];

            return new CarViewModel
            {
                Descriptor = model,
                Weight = GenerateRandomDouble(1000, 10000),
                Width = GenerateRandomDouble(5, 10),
                Height = GenerateRandomDouble(4, 8),
                Length = GenerateRandomDouble(10, 20),
                Manufacturer = make,
                ModelYear = (uint)GenerateRandomInt(1900, 2025),
                BodyStyle = bodyStyle,
                Fuel = fuel
            };
        }

        /// <summary>
        /// Creates a new instance of a <see cref="BoatViewModel"/> with randomized properties.
        /// </summary>
        /// <returns>A new <see cref="BoatViewModel"/> instance with randomized properties.</returns>
        public static BoatViewModel CreateRandomBoatViewModel()
        {
            var (manufacturer, model, power) = BoatSpecifications[_random.Next(BoatSpecifications.Length)];

            return new BoatViewModel
            {
                Descriptor = model,
                Weight = GenerateRandomDouble(1000, 1000000),
                Width = GenerateRandomDouble(5, 500),
                Height = GenerateRandomDouble(4, 300),
                Length = GenerateRandomDouble(10, 1500),
                Power = power,
                Draft = GenerateRandomDouble(1, 50),
                Manufacturer = manufacturer
            };
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
