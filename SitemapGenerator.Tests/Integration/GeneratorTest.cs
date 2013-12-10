using System.IO;
using System.Linq;
using System.Xml;
using NUnit.Framework;
using SitemapGenerator.Url;
using SitemapGenerator.Writers;

namespace SitemapGenerator.Tests.Integration
{
    [TestFixture]
    public class GeneratorTest
    {

        [Test]
        public void GenerateMapSetWithIndexes()
        {
            IUrlWriter<IIndexUrl> indexWriter = new FileSitemapWriter<IIndexUrl>("C:\\1\\generatedSitemap\\index.xml", rootUrl);
            string baseDirPath = "C:\\1\\generatedSitemap";
            Generator generator = new Generator(rootUrl, baseDirPath, indexWriter, "sitemap{0}.xml", 1024, 100);
            generator.Start();
            int urlCount = 32;

            for (int i = 0; i < urlCount; ++i)
            {
                generator.AddUrl(new SitemapUrl(i.ToString()));
            }
            generator.Stop();
            indexWriter.Dispose();

            int totatlUriCount = 0;

            DirectoryInfo dirInfo = new DirectoryInfo(baseDirPath);

            foreach (FileInfo file in dirInfo.EnumerateFiles().Where(x => x.Name != "index.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(File.ReadAllText(file.FullName));
                var urlSet = doc.ChildNodes[1];
                totatlUriCount += urlSet.ChildNodes.Count;
                Assert.IsTrue(file.Length < 1024);
            }

            Assert.AreEqual(urlCount, totatlUriCount);
        }

        private string rootUrl = "http://gorod55.ru";
    }
}
