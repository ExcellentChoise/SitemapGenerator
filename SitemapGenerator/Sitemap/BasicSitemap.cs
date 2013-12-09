using System.Collections.Generic;

namespace SitemapGenerator.Sitemap
{
    public class BasicSitemap : SitemapBase
    {
        public BasicSitemap()
        {
            urls = new LinkedList<ISiteMapUrl>();
        }

        public override void Add(ISiteMapUrl sitemapUrl)
        {
            urls.AddLast(sitemapUrl);
        }

        public override IEnumerator<ISiteMapUrl> GetEnumerator()
        {
            return urls.GetEnumerator();
        }

        private readonly LinkedList<ISiteMapUrl> urls;
    }
}