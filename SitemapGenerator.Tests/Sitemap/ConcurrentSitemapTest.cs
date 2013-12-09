using System.Linq;
using NUnit.Framework;
using SitemapGenerator.Sitemap;

namespace SitemapGenerator.Tests.Sitemap
{
    [TestFixture]
    public class ConcurrentSitemapTest : SitemapTestBase
    {
        [Test]
        public void WhenMultipleThreadsAddUrlsToMap_ShouldStoreAllGivenUrls()
        {
            const int iterations = 1000;
            ISitemap map = CreateSitemap();

            Enumerable.Range(0, iterations)
                .AsParallel()
                .ForAll(x => map.Add(CreateSitemapUrl("http://www.google.com//" + x)));

            Assert.AreEqual(iterations, map.Count());
        }

        public override ISitemap CreateSitemap(params ISiteMapUrl[] urls)
        {
            return new ConcurrentSitemap();
        }

        public override ISiteMapUrl CreateSitemapUrl(string url)
        {
            return new SiteMapUrl(url);
        }
    }
}