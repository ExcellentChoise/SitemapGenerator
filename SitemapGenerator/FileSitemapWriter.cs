using System;
using System.IO;

namespace SitemapGenerator
{
    public class FileSitemapWriter : ISiteMapWriter
    {
        public FileSitemapWriter(string path, string rootUrl)
        {
            streamWriter = new SitemapStreamWriter(new FileStream(path, FileMode.Create), rootUrl);
        }

        public void WriteSitemapUrl(IUrl sitemapUrl)
        {
            streamWriter.WriteSitemapUrl(sitemapUrl);
        }

        public long GetTotalEstimatedBytes()
        {
            return streamWriter.GetTotalEstimatedBytes();
        }

        private SitemapStreamWriter streamWriter;
        private bool disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                }

                streamWriter.Dispose();
                disposed = true;
            }
        }
    }
}