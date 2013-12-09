using SitemapGenerator.Sitemap;

namespace SitemapGenerator.Tests.Sitemap
{
    public class BasicSitemapTest : SitemapTestBase
    {
        public override ISitemap CreateSitemap(params ISitemapUrl[] urls)
        {
            return new BasicSitemap("basic", "http://www.google.com");
        }

        public override ISitemapUrl CreateSitemapUrl(string url)
        {
            return new SitemapUrl(url);
        }
    }
}