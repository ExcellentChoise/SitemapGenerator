using System.Runtime.Serialization;

namespace SitemapGenerator
{
    public enum ChangeFrequency
    {
        [EnumMember(Value = "always")] Always = 1,
        [EnumMember(Value = "hourly")] Hourly = 2,
        [EnumMember(Value = "daily")] Daily = 3,
        [EnumMember(Value = "weekly")] Weekly = 4,
        [EnumMember(Value = "monthly")] Monthly = 5,
        [EnumMember(Value = "yearly")] Yearly = 6,
        [EnumMember(Value = "never")] Never = 7,
    }
}