using System.Collections.Generic;

namespace SitemapGenerator
{
    public interface ISitemap : IEnumerable<ISitemapUrl>
    {
        void Add(ISitemapUrl sitemapUrl);
        string Name { get; }
        string RootUrl { get; }
    }
}