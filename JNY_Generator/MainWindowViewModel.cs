using System.IO;
using System.Windows.Input;
using JNY_Generator.BaseClasses;
using JNY_Generator.Factories;
using JNY_Generator.Utilities;
using JNY_Generator.Vehicles;

namespace JNY_Generator
{
    /// <summary>
    /// ViewModel for the MainWindow, following the MVVM design pattern.
    /// </summary>
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Attributes

        private ICommand? _buildRandomCarCommand;
        private ICommand? _buildRandomBoatCommand;
        private ICommand? _saveToFileCommand;
        private string _vehicleFilePreview = "";
        private VehicleViewModel? _vehicleViewModel;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// Command to build a random car.
        /// </summary>
        public ICommand BuildRandomCarCommand => _buildRandomCarCommand ??= new RelayCommand(_ => BuildRandomCar());

        /// <summary>
        /// Command to build a random boat.
        /// </summary>
        public ICommand BuildRandomBoatCommand => _buildRandomBoatCommand ??= new RelayCommand(_ => BuildRandomBoat());

        /// <summary>
        /// Command to save the vehicle to a file.
        /// </summary>
        public ICommand SaveToFileCommand => _saveToFileCommand ??= new RelayCommand(_ => SaveVehicleToFile(), _ => _vehicleViewModel != null);

        /// <summary>
        /// Preview of the vehicle file content.
        /// </summary>
        public string VehicleFilePreview
        {
            get => _vehicleFilePreview;
            set => SetProperty(ref _vehicleFilePreview, value);
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Builds a random car and updates the vehicle preview.
        /// </summary>
        private void BuildRandomCar()
        {
            _vehicleViewModel = VehicleFactory.CreateRandomCarViewModel();
            _vehicleViewModel.Waypoints.AddRange(WaypointFactory.GenerateRandomCarWaypoints());

            BuildVehiclePreview();
        }

        /// <summary>
        /// Builds a random boat and updates the vehicle preview.
        /// </summary>
        private void BuildRandomBoat()
        {
            var boat = VehicleFactory.CreateRandomBoatViewModel();
            _vehicleViewModel = boat;
            _vehicleViewModel.Waypoints.AddRange(WaypointFactory.GenerateRandomBoatWaypoints(boat.Power));

            BuildVehiclePreview();
        }

        /// <summary>
        /// Builds the vehicle preview by serializing the vehicle to a memory stream.
        /// </summary>
        private void BuildVehiclePreview()
        {
            if (_vehicleViewModel == null)
            {
                VehicleFilePreview = "";
                return;
            }

            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    Serializer.SerializeToStream(_vehicleViewModel, memoryStream);
                    memoryStream.Position = 0;
                    using (var reader = new StreamReader(memoryStream))
                    {
                        VehicleFilePreview = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(
                    $"Error generating vehicle preview: {ex.Message}", 
                    "Error", 
                    System.Windows.MessageBoxButton.OK, 
                    System.Windows.MessageBoxImage.Error);
                VehicleFilePreview = "";
            }
        }

        /// <summary>
        /// Saves the vehicle to a .JNY file using a SaveFileDialog.
        /// </summary>
        private void SaveVehicleToFile()
        {
            if (_vehicleViewModel == null)
            {
                return;
            }

            var saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "JNY files (*.JNY)|*.JNY",
                DefaultExt = ".JNY",
                FileName = _vehicleViewModel.Identifier,
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    Serializer.SerializeToFile(_vehicleViewModel, saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(
                        $"Error saving file: {ex.Message}", 
                        "Error", 
                        System.Windows.MessageBoxButton.OK, 
                        System.Windows.MessageBoxImage.Error);
                }
            }
        }

        #endregion Methods
    }
}
