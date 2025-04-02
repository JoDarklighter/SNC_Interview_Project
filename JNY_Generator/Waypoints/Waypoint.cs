using JNY_Generator.DataAttributes;

namespace JNY_Generator.Waypoints
{
    public class Waypoint
    {
        /// <summary>
        /// The latitude of this waypoint in decimal degrees.
        /// </summary>
        [FieldOrder(0)]
        public double Latitude { get; set; }

        /// <summary>
        /// The longitude of this waypoint in decimal degrees.
        /// </summary>
        [FieldOrder(1)]
        public double Longitude { get; set; }

        /// <summary>
        /// The delta time of this waypoint in seconds.
        /// </summary>
        [FieldOrder(2)]
        public double DeltaTime { get; set; }
    }
}
