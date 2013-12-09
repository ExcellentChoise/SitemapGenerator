using System;

namespace SitemapGenerator
{
    public interface ISiteMapUrl
    {
        string Url { get; }
        DateTime LastModifyDate { get; }
        ChangeFrequency FrequencyOfChange {get;}
    }
}