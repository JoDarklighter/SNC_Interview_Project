using JNY_Generator.DataAttributes;
using JNY_Generator.Enums;

namespace JNY_Generator.Vehicles
{
    public class CarViewModel : VehicleViewModel
    {
        private string _manufacturer = "";
        private uint _modelYear;
        private BodyStyleEnum _bodyStyle;
        private FuelEnum _fuel;

        /// <summary>
        /// The manufacturer name of the car.
        /// </summary>
        [FieldOrder(6)]
        public string Manufacturer
        {
            get => _manufacturer;
            set => SetProperty(ref _manufacturer, value);
        }

        /// <summary>
        /// The model year of the car.
        /// </summary>
        [FieldOrder(7)]
        public uint ModelYear
        {
            get => _modelYear;
            set => SetProperty(ref _modelYear, value);
        }

        /// <summary>
        /// The body style of the car.
        /// </summary>
        [FieldOrder(8)]
        public BodyStyleEnum BodyStyle
        {
            get => _bodyStyle;
            set => SetProperty(ref _bodyStyle, value);
        }

        /// <summary>
        /// The fuel source for the car.
        /// </summary>
        [FieldOrder(9)]
        public FuelEnum Fuel
        {
            get => _fuel;
            set => SetProperty(ref _fuel, value);
        }
    }
}
