using System;
using System.IO;
using System.Text;
using System.Xml;

namespace SitemapGenerator
{
    public class SitemapStreamWriter : ISiteMapWriter, IDisposable
    {
        public SitemapStreamWriter(Stream stream, string rootUrl)
        {
            writer = new XmlTextWriter(stream, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            this.rootUrl = rootUrl.TrimEnd('/', '\\');
            StartWriteSiteMap();
        }

        private void StartWriteSiteMap()
        {
            WriteHeaders();
        }

        public void FinishWriteMap()
        {
            WriteCloseTags();
            writer.Flush();
            writer.Close();
        }

        public void WriteSitemapUrl(IUrl siteMapUrl)
        {
            writer.WriteStartElement("url");
            writer.WriteElementString("loc", rootUrl + "//" + siteMapUrl.Url);
            writer.WriteElementString("changefreq", EnumSerializer<ChangeFrequency>.ToString(siteMapUrl.FrequencyOfChange));
            writer.WriteElementString("lastmod", siteMapUrl.LastModifyDate.ToString("yyyy-MM-dd"));
        }

        private void WriteHeaders()
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("urlset");
            writer.WriteAttributeString("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");
            writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xsi:schemaLocation", "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");
        }

        private void WriteCloseTags()
        {
            writer.WriteEndElement();
        }

        public long GetTotalEstimatedBytes()
        {
            return writer.BaseStream.Length + serviceFieldSizeBytes;
        }

        private XmlTextWriter writer;
        private string rootUrl;
        private long serviceFieldSizeBytes = 500; //TODO
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

                FinishWriteMap();
                disposed = true;
            }
        }
    }
}