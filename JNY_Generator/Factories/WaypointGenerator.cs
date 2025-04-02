using JNY_Generator.Enums;
using JNY_Generator.SNC;
using JNY_Generator.Waypoints;

namespace JNY_Generator.Factories
{
    public static class WaypointFactory
    {
        private static readonly Random _random = new Random();

        private const double SecondsPerHour = 3600.0;
        private const double FeetPerMile = 5280.0;
        private const double CarMinSpeedMph = 25.0;
        private const double CarMaxSpeedMph = 60.0;
        private const double CarMaxTurnDegrees = 90.0;
        private const double BoatMaxTurnDegrees = 30.0;

        private static readonly Dictionary<PowerEnum, (double MinSpeedMph, double MaxSpeedMph)> BoatSpeedRanges = new()
        {
            { PowerEnum.MOTOR, (25.0, 60.0) },
            { PowerEnum.SAIL, (15.0, 30.0) },
            { PowerEnum.UNPOWERED, (1.0, 10.0) }
        };

        private static readonly (double MinLat, double MaxLat, double MinLon, double MaxLon)[] Zones = new[]
        {
            (15.6, 56.2, -49.8, -23.1),
            (-48.8, -6.9, -28.6, 8.2),
            (-43.4, 8.1, -161.4, -98.4),
            (-41.1, -1.4, 62.2, 94.5)
        };

        /// <summary>
        /// Generates a random set of waypoints for a car.
        /// </summary>
        /// <param name="minWaypoints">The minimum number of waypoints to generate.</param>
        /// <param name="maxWaypoints">The maximum number of waypoints to generate.</param>
        /// <returns>A list of randomly generated waypoints for a car.</returns>
        public static List<Waypoint> GenerateRandomCarWaypoints(int minWaypoints = 10, int maxWaypoints = 30)
        {
            double currentLat = Math.Round(_random.NextDouble() * 180 - 90, 6); // Random starting latitude between -90 and 90 degrees, limited to 6 decimal places
            double currentLon = Math.Round(_random.NextDouble() * 360 - 180, 6); // Random starting longitude between -180 and 180 degrees, limited to 6 decimal places

            var waypoints = new List<Waypoint>()
            {
                new Waypoint
                {
                    Latitude = currentLat,
                    Longitude = currentLon,
                    DeltaTime = 0
                }
            };

            double currentBearing = _random.NextDouble() * 360; // Random starting bearing between 0 and 360 degrees

            int waypointCount = _random.Next(minWaypoints, maxWaypoints + 1) - 1;

            for (int i = 0; i < waypointCount; i++)
            {
                double speed = (_random.NextDouble() * (CarMaxSpeedMph - CarMinSpeedMph) + CarMinSpeedMph) * FeetPerMile / SecondsPerHour; // Speed in feet per second
                double deltaTime = Math.Round(_random.NextDouble() * 60, 2); // random time between 0 and 60 seconds, limited to 2 decimal places
                double distance = speed * deltaTime; // Distance in feet

                GeoCalc.GetEndingCoordinates(currentLat, currentLon, currentBearing, distance, out double nextLat, out double nextLon, out double endBearing);

                waypoints.Add(new Waypoint
                {
                    Latitude = Math.Round(nextLat, 6),
                    Longitude = Math.Round(nextLon, 6),
                    DeltaTime = deltaTime
                });

                currentLat = nextLat;
                currentLon = nextLon;
                currentBearing = (endBearing + _random.NextDouble() * (CarMaxTurnDegrees * 2) - CarMaxTurnDegrees) % 360; // Change bearing within car limits
            }

            return waypoints;
        }

        /// <summary>
        /// Generates a random set of waypoints for a boat.
        /// </summary>
        /// <param name="powerSource">The power source of the boat.</param>
        /// <param name="minWaypoints">The minimum number of waypoints to generate.</param>
        /// <param name="maxWaypoints">The maximum number of waypoints to generate.</param>
        /// <returns>A list of randomly generated waypoints for a boat.</returns>
        public static List<Waypoint> GenerateRandomBoatWaypoints(PowerEnum powerSource, int minWaypoints = 10, int maxWaypoints = 30)
        {
            var (minLat, maxLat, minLon, maxLon) = Zones[_random.Next(Zones.Length)];

            double currentLat = Math.Round(_random.NextDouble() * (maxLat - minLat) + minLat, 6); // Random starting latitude within the chosen zone, limited to 6 decimal places
            double currentLon = Math.Round(_random.NextDouble() * (maxLon - minLon) + minLon, 6); // Random starting longitude within the chosen zone, limited to 6 decimal places

            var waypoints = new List<Waypoint>()
            {
                new Waypoint
                {
                    Latitude = currentLat,
                    Longitude = currentLon,
                    DeltaTime = 0
                }
            };

            double currentBearing = _random.NextDouble() * 360; // Random starting bearing between 0 and 360 degrees

            int waypointCount = _random.Next(minWaypoints, maxWaypoints + 1) - 1; //
            var (minSpeedMph, maxSpeedMph) = BoatSpeedRanges[powerSource];

            for (int i = 0; i < waypointCount; i++)
            {
                double speed = (_random.NextDouble() * (maxSpeedMph - minSpeedMph) + minSpeedMph) * FeetPerMile / SecondsPerHour; // Speed in feet per second
                double deltaTime = Math.Round(_random.NextDouble() * 60, 2); // random time between 0 and 60 seconds, limited to 2 decimal places
                double distance = speed * deltaTime; // Distance in feet

                GeoCalc.GetEndingCoordinates(currentLat, currentLon, currentBearing, distance, out double nextLat, out double nextLon, out double endBearing);

                // Ensure the next waypoint is within the zone, otherwise skip this iteration and try again
                if (nextLat < minLat || nextLat > maxLat || nextLon < minLon || nextLon > maxLon)
                {
                    i--;
                    continue;
                }

                waypoints.Add(new Waypoint
                {
                    Latitude = Math.Round(nextLat, 6),
                    Longitude = Math.Round(nextLon, 6),
                    DeltaTime = deltaTime
                });

                currentLat = nextLat;
                currentLon = nextLon;
                currentBearing = (endBearing + _random.NextDouble() * BoatMaxTurnDegrees * 2 - BoatMaxTurnDegrees) % 360; // Change bearing within boat limits
            }

            return waypoints;
        }
    }
}
