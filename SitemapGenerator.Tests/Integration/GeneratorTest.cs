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
            IUrlWriter<IIndexUrl> indexWriter = new FileSitemapWriter<IIndexUrl>("C:\\1\\generatedSitemap\\" + indexFileName, rootUrl);
            int maxSitemapSizeBytes = 1024;
            int urlCount = 32;

            SitemapGeneratorBase sitemapGenerator = new SitemapGeneratorBase(rootUrl, baseDirPath, indexWriter, "sitemap{0}.xml", maxSitemapSizeBytes, 10);
            RunGenerator(urlCount, indexWriter, sitemapGenerator);

            CheckTotalSitemapsUrlsCountAndFileSize(urlCount, maxSitemapSizeBytes, baseDirPath);
        }

        private static void RunGenerator(int urlCount, IUrlWriter<IIndexUrl> indexWriter, SitemapGeneratorBase sitemapGenerator)
        {
            sitemapGenerator.Start();

            for (int i = 0; i < urlCount; ++i)
            {
                sitemapGenerator.AddUrl(new SitemapUrl(i.ToString() + ""));
            }

            sitemapGenerator.Stop();
            indexWriter.Dispose();
        }

        private static void CheckTotalSitemapsUrlsCountAndFileSize(int urlCount, int maxSitemapSizeBytes, string baseDirPath)
        {
            int totatlUriCount = 0;
            DirectoryInfo dirInfo = new DirectoryInfo(baseDirPath);

            foreach (FileInfo file in dirInfo.EnumerateFiles().Where(x => x.Name != indexFileName))
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(File.ReadAllText(file.FullName));
                var urlSet = doc.ChildNodes[1];
                totatlUriCount += urlSet.ChildNodes.Count;
                Assert.IsTrue(file.Length < maxSitemapSizeBytes);
            }

            Assert.AreEqual(urlCount, totatlUriCount);
        }

        private string rootUrl = "http://gorod55.ru";
        private string baseDirPath = "C:\\1\\generatedSitemap";
        private static string indexFileName = "index.xml";
    }
}
