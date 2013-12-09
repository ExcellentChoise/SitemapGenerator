using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace SitemapGenerator
{
    public class EnumSerializer<TEnum>
    {
        private static readonly Dictionary<TEnum, string> correspondence;

        static EnumSerializer()
        {
            correspondence = new Dictionary<TEnum, string>();
            foreach (object value in Enum.GetValues(typeof (TEnum)))
            {
                var attribute = value.GetType()
                    .GetField(value.ToString())
                    .GetCustomAttributes(typeof (EnumMemberAttribute), false)
                    .SingleOrDefault() as EnumMemberAttribute;
                string valueName = attribute == null ? value.ToString() : attribute.Value;
                correspondence.Add((TEnum) value, valueName);
            }
        }

        public static string ToString(TEnum value)
        {
            return correspondence[value];
        }
    }
}