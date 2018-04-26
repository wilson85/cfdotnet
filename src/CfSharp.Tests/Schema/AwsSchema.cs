using System;
using System.Collections.Generic;
using System.Text;

namespace CfSharp.Tests.Schema
{
    public class AwsSchema
    {
        public string ResourceSpecificationVersion { get; set; }

        public ResourceType ResourceType { get; set; }
    }

    public class ResourceType : Dictionary<string, Resource>
    {

    }

    public class Resource
    {
        /// <summary>
        /// Link to the relevant documentation
        /// </summary>
        public string Documentation { get; set; }

        public ResourceProperties Properties { get; set; }

        public ResourceAttributes Attributes { get; set; }

    }

    public class ResourceAttributes : Dictionary<string, ResourceAttribute>
    {

    }

    public class ResourceAttribute
    {
        /// <summary>
        /// Return list or map type (non-primitive)
        /// </summary>
        public int ItemType { get; set; }

        /// <summary>
        /// Return list or map type (primitive)
        /// </summary>
        public string PrimitiveItemType { get; set; }

        /// <summary>
        /// Return value type (primitive)
        /// </summary>
        public string PrimitiveType { get; set; }

        /// <summary>
        /// Return value type (non-primitive)
        /// </summary>
        public string Type { get; set; }

    }

    public class ResourceProperties : Dictionary<string, ResourceProperty>
    {

    }

    public class ResourceProperty
    {
        /// <summary>
        /// Link to the relevant documentation
        /// </summary>
        public string Documentation { get; set; }

        public bool? DuplicatesAllowed { get; set; }

        /// <summary>
        /// Type of list or map (non-primitive)
        /// </summary>
        public string ItemType { get; set; }

        /// <summary>
        /// Type of list or map (primitive)
        /// </summary>
        public string PrimitiveItemType { get; set; }

        /// <summary>
        /// Type of value (primitive)
        /// </summary>
        public string PrimitiveType { get; set; }

        public bool Required { get; set; }

        /// <summary>
        /// Type of value (non-primitive)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Mutable, Immutable, or Conditional
        /// </summary>
        public string UpdateType { get; set; }
    }
}

