using System;
using System.IO;
using System.Text;
using System.Xml;
using SitemapGenerator.Url;

namespace SitemapGenerator.Writers
{
    // Method WriteLocation is thread safe
    public class IndexStreamWriter : IUrlWriter<IIndexUrl>
    {
        public IndexStreamWriter(Stream stream, string rootUrl)
        {
            indexWriter = new XmlTextWriter(stream, Encoding.UTF8);
            indexWriter.Formatting = Formatting.Indented;
            this.rootUrl = rootUrl.TrimEnd('/', '\\');
            StartWriteIndex();
        }

        private void StartWriteIndex()
        {
            WriteHeaders();
        }

        public void WriteLocation(IIndexUrl indexUrl)
        {
            lock (lockObject)
            {
                indexWriter.WriteStartElement("sitemap");
                indexWriter.WriteElementString("loc", rootUrl + "/" + indexUrl.Url);
                indexWriter.WriteElementString("lastmod", indexUrl.LastModifyDate.ToString("yyyy-MM-dd"));
                indexWriter.WriteEndElement();   
            }
        }

        private void WriteHeaders()
        {
            indexWriter.WriteStartDocument();
            indexWriter.WriteStartElement("sitemapindex");
            indexWriter.WriteAttributeString("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");
            indexWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            indexWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/siteindex.xsd");
        }

        private void WriteCloseTags()
        {
            indexWriter.WriteEndElement();
        }

        public long GetTotalEstimatedBytes()
        {
            return indexWriter.BaseStream.Length + serviceFieldSizeBytes;
        }

        private XmlTextWriter indexWriter;
        private string rootUrl;
        private long serviceFieldSizeBytes = 512;
        private object lockObject = new object();
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

                WriteCloseTags();
                indexWriter.Flush();
                indexWriter.Close();
                disposed = true;
            }
        }
    }
}
