using System;
using System.IO;
using SitemapGenerator.Url;

namespace SitemapGenerator.Writers
{
    public class FileSitemapWriter<TUrl> : IUrlWriter<TUrl> where TUrl : IUrl
    {
        public FileSitemapWriter(string path, string rootUrl)
        {
            streamWriter = StreaWritersFactory.CreateWriter<TUrl>(new FileStream(path, FileMode.Create), rootUrl);
        }

        public void WriteLocation(TUrl sitemapUrl)
        {
            streamWriter.WriteLocation(sitemapUrl);
        }

        public long GetTotalEstimatedBytes()
        {
            return streamWriter.GetTotalEstimatedBytes();
        }

        private IUrlWriter<TUrl> streamWriter;
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