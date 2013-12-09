using System;

namespace SitemapGenerator
{
    public interface ISitemapUrl
    {
        string Url { get; }
        DateTime LastModifyDate { get; }
        ChangeFrequency FrequencyOfChange {get;}
        decimal Priority { get; }
    }
}