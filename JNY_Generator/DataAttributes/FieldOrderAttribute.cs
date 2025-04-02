namespace JNY_Generator.DataAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    internal class FieldOrderAttribute : Attribute
    {
        public int Order { get; }

        public FieldOrderAttribute(int order)
        {
            Order = order;
        }
    }
}
