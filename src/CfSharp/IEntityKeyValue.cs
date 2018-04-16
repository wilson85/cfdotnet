namespace CfSharp
{
    public class EntityKeyValue
    {
        public EntityKeyValue(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public object Value { get; }
    }

    public interface IEntityValue
    {
        object Value { get; }
    }

    public class EntityReference
    {
        public EntityReference(object @ref)
        {
            Ref = @ref;
        }

        public object Ref { get; set; }
    }
}
