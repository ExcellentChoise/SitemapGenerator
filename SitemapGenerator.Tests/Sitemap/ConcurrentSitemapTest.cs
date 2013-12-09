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

        public override ISitemap CreateSitemap(params ISitemapUrl[] urls)
        {
            return new ConcurrentSitemap("concurrent", "http://www.google.com/");
        }

        public override ISitemapUrl CreateSitemapUrl(string url)
        {
            return new SitemapUrl(url);
        }
    }
}