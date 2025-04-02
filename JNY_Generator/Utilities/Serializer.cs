using System.IO;
using System.Reflection;
using JNY_Generator.DataAttributes;
using JNY_Generator.Vehicles;

namespace JNY_Generator.Utilities
{
    /// <summary>
    /// Provides methods for serializing <see cref="VehicleViewModel"> objects to files and streams.
    /// </summary>
    public static class Serializer
    {
        /// <summary>
        /// Serializes the specified <see cref="VehicleViewModel"> to a file.
        /// </summary>
        /// <param name="viewModel">The VehicleViewModel to serialize.</param>
        /// <param name="filePath">The path of the file to write to.</param>
        public static void SerializeToFile(VehicleViewModel viewModel, string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                SerializeToStream(viewModel, fileStream);
            }
        }

        /// <summary>
        /// Serializes the specified <see cref="VehicleViewModel"> to a stream.
        /// </summary>
        /// <param name="viewModel">The <see cref="VehicleViewModel"> to serialize.</param>
        /// <param name="stream">The stream to write to.</param>
        public static void SerializeToStream(VehicleViewModel viewModel, Stream stream)
        {
            var properties = GetOrderedProperties(viewModel);
            var values = properties.Select(p => p.GetValue(viewModel)?.ToString() ?? string.Empty);
            var content = string.Join(",", values);

            foreach (var waypoint in viewModel.Waypoints)
            {
                var waypointProperties = GetOrderedProperties(waypoint);
                var waypointValues = waypointProperties.Select(p => p.GetValue(waypoint)?.ToString() ?? string.Empty);
                var waypointContent = string.Join(",", waypointValues);
                content += Environment.NewLine + waypointContent;
            }

            using (var writer = new StreamWriter(stream, leaveOpen: true))
            {
                writer.Write(content);
            }
        }

        /// <summary>
        /// Gets the properties of the specified object, ordered by the FieldOrder attribute.
        /// </summary>
        /// <param name="obj">The object to get properties from.</param>
        /// <returns>An IEnumerable of PropertyInfo objects, ordered by the FieldOrder attribute.</returns>
        private static IEnumerable<PropertyInfo> GetOrderedProperties(object obj)
        {
            return obj.GetType()
                      .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                      .Where(p => p.GetCustomAttribute<FieldOrderAttribute>() != null)
                      .OrderBy(p => p.GetCustomAttribute<FieldOrderAttribute>()?.Order);
        }
    }
}
