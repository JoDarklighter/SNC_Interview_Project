using JNY_Generator.DataAttributes;
using JNY_Generator.Enums;

namespace JNY_Generator.Vehicles
{
    public class BoatViewModel : VehicleViewModel
    {
        private PowerEnum _power;
        private double _draft;
        private string _manufacturer = "";

        /// <summary>
        /// The power source of the boat.
        /// </summary>
        [FieldOrder(6)]
        public PowerEnum Power
        {
            get => _power;
            set => SetProperty(ref _power, value);
        }

        /// <summary>
        /// The draft of the boat in feet.
        /// </summary>
        [FieldOrder(7)]
        public double Draft
        {
            get => _draft;
            set => SetProperty(ref _draft, value);
        }

        /// <summary>
        /// The manufacturer name of the boat.
        /// </summary>
        [FieldOrder(8)]
        public string Manufacturer
        {
            get => _manufacturer;
            set => SetProperty(ref _manufacturer, value);
        }
    }
}
