using System.Collections.Generic;

namespace CfSharp
{
    public class Tags : List<Tag>
    {

    }

    public class Tag : KeyValuePair
    {
        public Tag(string key, object value) : base(key, value)
        {
        }
    }
}
