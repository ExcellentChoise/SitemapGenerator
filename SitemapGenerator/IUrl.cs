using System;

namespace SitemapGenerator
{
    public interface IUrl
    {
        string Url { get; }
        DateTime LastModifyDate { get; }
        ChangeFrequency FrequencyOfChange { get; }
        decimal Priority { get; }
    }

    public interface IIndexUrl : IUrl
    {
    }

    public interface ISitemapUrl : IUrl
    {
        ChangeFrequency FrequencyOfChange { get; }
        decimal Priority { get; }
    }
}