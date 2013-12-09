using System.Linq;
using NUnit.Framework;

namespace SitemapGenerator.Tests
{
    [TestFixture]
    public abstract class SitemapTestBase
    {
        public abstract ISitemap CreateSitemap(params ISiteMapUrl[] urls);
        public abstract ISiteMapUrl CreateSitemapUrl(string url);

        [Test]
        public void WhenUrlAdded_Enumeration_ShouldReturnThisUrl()
        {
            ISitemap map = CreateSitemap();
            ISiteMapUrl url = CreateSitemapUrl("http://www.google.com//");

            map.Add(url);

            ISiteMapUrl urlAfterEnumeration = map.Single();
            Assert.AreEqual(urlAfterEnumeration.Url, urlAfterEnumeration.Url);
        }
    }
}