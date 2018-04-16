using System;
using System.Collections.Generic;

namespace CfSharp
{
    public static class EntityExtensions
    {
        public static FnGetAtt Attr(this IEntity entity, string attributeName)
        {
            return Functions.GetAtt(entity, attributeName);
        }

        public static void Configure<T>(this IEnumerable<T> entity, Action<T> action)
            where T : IEntity
        {
            foreach (var item in entity)
            {
                action(item);
            }
        }
    }
}
