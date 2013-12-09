using System.Collections.Concurrent;
using System.Collections.Generic;

namespace SitemapGenerator.Sitemap
{
    public class ConcurrentSitemap : SitemapBase
    {
        public ConcurrentSitemap(string name, string rootUrl) : base(name, rootUrl)
        {
            urls = new ConcurrentBag<ISitemapUrl>();
        }        

        public  override void Add(ISitemapUrl sitemapUrl)
        {
            urls.Add(sitemapUrl);
        }

        public override IEnumerator<ISitemapUrl> GetEnumerator()
        {
            return urls.GetEnumerator();
        }

        private readonly ConcurrentBag<ISitemapUrl> urls;
    }
}