namespace CfSharp
{
    public class KeyValuePair
    {
        public KeyValuePair(string key, object value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }

        public object Value { get; set; }
    }
}
