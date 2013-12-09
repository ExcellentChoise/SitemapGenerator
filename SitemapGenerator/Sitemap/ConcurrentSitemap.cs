using System.Collections.Concurrent;
using System.Collections.Generic;

namespace SitemapGenerator.Sitemap
{
    public class ConcurrentSitemap : SitemapBase
    {
        public ConcurrentSitemap()
        {
            urls = new ConcurrentBag<ISiteMapUrl>();
        }        

        public  override void Add(ISiteMapUrl sitemapUrl)
        {
            urls.Add(sitemapUrl);
        }

        public override IEnumerator<ISiteMapUrl> GetEnumerator()
        {
            return urls.GetEnumerator();
        }

        private readonly ConcurrentBag<ISiteMapUrl> urls;
    }
}