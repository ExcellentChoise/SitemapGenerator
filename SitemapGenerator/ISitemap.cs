using System.Collections.Generic;

namespace SitemapGenerator
{
    public interface ISitemap : IEnumerable<ISiteMapUrl>
    {
        void Add(ISiteMapUrl sitemapUrl);
    }
}