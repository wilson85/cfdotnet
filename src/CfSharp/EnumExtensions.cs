using System;
using System.ComponentModel;
using System.Reflection;

namespace CfSharp
{
    public static class EnumExtensions
    {
        public static string GetDescription<T>(this T @enum) where T : struct
        {
            Type type = @enum.GetType();

            MemberInfo[] memberInfo = type.GetMember(@enum.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return @enum.ToString();
        }
    }
}
