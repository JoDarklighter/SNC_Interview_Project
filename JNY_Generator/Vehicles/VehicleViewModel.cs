using JNY_Generator.BaseClasses;
using JNY_Generator.DataAttributes;
using JNY_Generator.Waypoints;

namespace JNY_Generator.Vehicles
{
    public abstract class VehicleViewModel : ViewModelBase
    {
        private string _descriptor = "";
        private double _weight;
        private double _width;
        private double _height;
        private double _length;

        /// <summary>
        /// Unique identifier for the type of vehicle.
        /// </summary>
        [FieldOrder(0)]
        public abstract string Identifier { get; }

        /// <summary>
        /// A human-readable description of the vehicle.
        /// </summary>
        [FieldOrder(1)]
        public string Descriptor
        {
            get => _descriptor;
            set => SetProperty(ref _descriptor, value);
        }

        /// <summary>
        /// The weight of the vehicle in pounds.
        /// </summary>
        [FieldOrder(2)]
        public double Weight
        {
            get => _weight;
            set => SetProperty(ref _weight, value);
        }

        /// <summary>
        /// The width of the vehicle in feet.
        /// </summary>
        [FieldOrder(3)]
        public double Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }

        /// <summary>
        /// The height of the vehicle in feet.
        /// </summary>
        [FieldOrder(4)]
        public double Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        /// <summary>
        /// The length of the vehicle in feet.
        /// </summary>
        [FieldOrder(5)]
        public double Length
        {
            get => _length;
            set => SetProperty(ref _length, value);
        }

        /// <summary>
        /// A collection of waypoints for the vehicle.
        /// </summary>
        public List<Waypoint> Waypoints
        {
            get;
        } = new List<Waypoint>();
    }
}
