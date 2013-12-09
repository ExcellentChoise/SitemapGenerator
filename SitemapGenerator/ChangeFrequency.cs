using System.ComponentModel;

namespace SitemapGenerator
{
    public enum ChangeFrequency
    {
        [Description("always")]
        Always,

        [Description("hourly")]
        Hourly,

        [Description("daily")]
        Daily,

        [Description("weekly")]
        Weekly,

        [Description("monthly")]
        Monthly,

        [Description("yearly")]
        Yearly,

        [Description("never")]
        Never
    }
}
