using System.Collections.Generic;

namespace SitemapGenerator
{
    public interface ISitemap : IEnumerable<IUrl>
    {
        void Add(IUrl sitemapUrl);
        string Name { get; }
        string RootUrl { get; }
    }
}