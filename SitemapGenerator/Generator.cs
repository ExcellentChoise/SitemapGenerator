using System;
using System.IO;
using SitemapGenerator.Url;
using SitemapGenerator.Writers;

namespace SitemapGenerator
{
    public class SitemapGeneratorBase : ISitemapGenerator
    {
        public SitemapGeneratorBase(string rootUrl, string baseDirPath, IUrlWriter<IIndexUrl> indexWriter)
        {
            this.rootUrl = rootUrl;
            this.baseDirPath = baseDirPath;
            this.indexWriter = indexWriter;
            maxSitemapSizeBytes -= maxElemWithUri;
        }

        public SitemapGeneratorBase(string rootUrl, string baseDirPath, IUrlWriter<IIndexUrl> indexWriter, string fileNamePattern, long maxSitemapSizeBytes, int maxUrlsCountAtSingleMap)
            : this(rootUrl, baseDirPath, indexWriter)
        {
            this.fileNamePattern = fileNamePattern;
            this.maxSitemapSizeBytes = maxSitemapSizeBytes - maxElemWithUri;
            this.maxUrlsCount = maxUrlsCountAtSingleMap;
        }

        public void Start()
        {
            sitemapWriter = CreateNewWriter();
            ++totalSitemapsCount;
        }

        public void Stop()
        {
            sitemapWriter.Dispose();
        }

        public void AddUrl(ISitemapUrl url)
        {
            if (sitemapWriter.GetTotalEstimatedBytes() >= maxSitemapSizeBytes || writtenUrlsCount >= maxUrlsCount)
            {
                sitemapWriter.Dispose();
                sitemapWriter = CreateNewWriter();
                ++totalSitemapsCount;
            }
          
            sitemapWriter.WriteLocation(url);
            ++writtenUrlsCount;
        }

        private IUrlWriter<ISitemapUrl> CreateNewWriter()
        {
            string fileName = string.Format(fileNamePattern, totalSitemapsCount);
            currentFileName = fileName;
            string filePath = Path.Combine(baseDirPath, fileName);
            writtenUrlsCount = 0;
            indexWriter.WriteLocation(new IndexUrlBase(DateTime.Now, currentFileName));

            return new FileSitemapWriter<ISitemapUrl>(filePath, rootUrl);
        }

        private IUrlWriter<ISitemapUrl> sitemapWriter;
        private IUrlWriter<IIndexUrl> indexWriter;
        private int totalSitemapsCount;
        private string fileNamePattern = "sitemap{0}.xml";
        private string baseDirPath;
        private string rootUrl;
        private int maxElemWithUri = 372;
        private long maxSitemapSizeBytes = 10 * 1024 * 1024;
        private int maxUrlsCount = 50000;
        private string currentFileName;
        private int writtenUrlsCount;
    }
}
