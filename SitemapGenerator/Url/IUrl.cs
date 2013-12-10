using System;

namespace SitemapGenerator.Url
{
    public interface IUrl
    {
        string Url { get; }
        DateTime LastModifyDate { get; }
    }
}