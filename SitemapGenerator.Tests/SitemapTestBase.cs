using System.Linq;
using NUnit.Framework;

namespace SitemapGenerator.Tests
{
    [TestFixture]
    public abstract class SitemapTestBase
    {
        public abstract ISitemap CreateSitemap(params ISitemapUrl[] urls);
        public abstract ISitemapUrl CreateSitemapUrl(string url);

        [Test]
        public void WhenUrlAdded_Enumeration_ShouldReturnThisUrl()
        {
            ISitemap map = CreateSitemap();
            ISitemapUrl url = CreateSitemapUrl("http://www.google.com//");

            map.Add(url);

            ISitemapUrl urlAfterEnumeration = map.Single();
            Assert.AreEqual(urlAfterEnumeration.Url, urlAfterEnumeration.Url);
        }
    }
}