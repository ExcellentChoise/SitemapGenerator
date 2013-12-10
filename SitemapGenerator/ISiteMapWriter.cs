using System;

namespace SitemapGenerator
{
    public interface ISiteMapWriter : IDisposable
    {
        void WriteSitemapUrl(IUrl sitemapUrl);
        long GetTotalEstimatedBytes();
    }
}