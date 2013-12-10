using System.Collections.Generic;
using SitemapGenerator.Url;

namespace SitemapGenerator.Sitemap
{
    public interface ISitemap : IEnumerable<ISitemapUrl>
    {
        void Add(ISitemapUrl sitemapUrl);
        string Name { get; }
        string RootUrl { get; }
    }
}