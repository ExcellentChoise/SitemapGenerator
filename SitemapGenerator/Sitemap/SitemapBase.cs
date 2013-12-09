using System.Collections;
using System.Collections.Generic;

namespace SitemapGenerator.Sitemap
{
    public abstract class SitemapBase : ISitemap
    {
        protected SitemapBase(string name, string rootUrl)
        {
            Name = name;
            RootUrl = rootUrl;
        }

        public abstract void Add(ISitemapUrl sitemapUrl);

        public string Name { get; private set; }
        public string RootUrl { get; private set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public abstract IEnumerator<ISitemapUrl> GetEnumerator();
    }
}
