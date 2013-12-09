using SitemapGenerator.Sitemap;

namespace SitemapGenerator.Tests.Sitemap
{
    public class BasicSitemapTest : SitemapTestBase
    {
        public override ISitemap CreateSitemap(params ISiteMapUrl[] urls)
        {
            return new BasicSitemap();
        }

        public override ISiteMapUrl CreateSitemapUrl(string url)
        {
            return new SiteMapUrl(url);
        }
    }
}