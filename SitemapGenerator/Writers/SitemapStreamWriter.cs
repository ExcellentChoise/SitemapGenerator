using System;
using System.IO;
using System.Text;
using System.Xml;
using SitemapGenerator.Url;

namespace SitemapGenerator.Writers
{
    public class SitemapStreamWriter : IUrlWriter<ISitemapUrl>
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
            totalEstimatedBytes += serviceFieldSizeBytes;
        }


        public void WriteLocation(ISitemapUrl siteMapUrl)
        {
            string fullUrl = rootUrl + "/" + siteMapUrl.Url;
            writer.WriteStartElement("url");
            writer.WriteElementString("loc", fullUrl);
            writer.WriteElementString("changefreq", EnumSerializer<ChangeFrequency>.ToString(siteMapUrl.FrequencyOfChange));
            writer.WriteElementString("lastmod", siteMapUrl.LastModifyDate.ToString("yyyy-MM-dd"));
            writer.WriteEndElement();
            totalEstimatedBytes += singleUrlServiceInfoLength;
            totalEstimatedBytes += fullUrl.Length;
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
            return totalEstimatedBytes;
        }

        private XmlTextWriter writer;
        private string rootUrl;
        private long serviceFieldSizeBytes = 512;
        private long singleUrlServiceInfoLength = 115;
        private long totalEstimatedBytes;

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
                writer.Flush();
                writer.Close();
                disposed = true;
            }
        }
    }
}