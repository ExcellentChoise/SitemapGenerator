using System;

namespace SitemapGenerator
{
    public class SiteMapUrl : ISiteMapUrl
    {
        public SiteMapUrl(string url)
        {
            Url = url;
            LastModifyDate = DateTime.Now;
            FrequencyOfChange = ChangeFrequency.Always;
        }

        public string Url { get; private set; }
        public DateTime LastModifyDate { get; private set; }
        public ChangeFrequency FrequencyOfChange { get; private set; }
    }
}