using System.Collections.Generic;

namespace SitemapGenerator.Sitemap
{
    public class BasicSitemap : SitemapBase
    {
        public BasicSitemap(string name, string rootUrl) 
            : base(name, rootUrl)
        {
            urls = new LinkedList<ISitemapUrl>();
        }

        public override void Add(ISitemapUrl sitemapUrl)
        {
            urls.AddLast(sitemapUrl);
        }

        public override IEnumerator<ISitemapUrl> GetEnumerator()
        {
            return urls.GetEnumerator();
        }

        private readonly LinkedList<ISitemapUrl> urls;
    }
}