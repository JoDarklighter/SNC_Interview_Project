using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JNY_Generator.BaseClasses
{
    /// <summary>
    /// Base class for ViewModels, providing property change notification.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Event that is raised when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event for the specified property.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets the property value and raises the PropertyChanged event if the value changes.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="field">The backing field of the property.</param>
        /// <param name="value">The new value of the property.</param>
        /// <param name="propertyName">The name of the property. This is optional and will be automatically provided by the compiler.</param>
        /// <returns>True if the value was changed, false if the value was the same as the existing value.</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
