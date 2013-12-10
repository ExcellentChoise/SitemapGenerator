using System;

namespace SitemapGenerator.Url
{
    public class IndexUrlBase : IIndexUrl
    {
        public IndexUrlBase(DateTime lastModifyDate, string url)
        {
            LastModifyDate = lastModifyDate;
            Url = url;
        }

        public string Url { get; private set; }
        public DateTime LastModifyDate { get; private set; }
    }
}