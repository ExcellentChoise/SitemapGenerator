using System.Collections;
using System.Collections.Generic;

namespace SitemapGenerator.Sitemap
{
    public abstract class SitemapBase : ISitemap
    {
        public abstract void Add(ISiteMapUrl sitemapUrl);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public abstract IEnumerator<ISiteMapUrl> GetEnumerator();
    }
}
