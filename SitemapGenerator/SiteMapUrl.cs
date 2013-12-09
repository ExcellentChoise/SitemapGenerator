using System;

namespace SitemapGenerator
{
    public class SitemapUrl : ISitemapUrl
    {
        public SitemapUrl(string url)
        {
            Url = url;
            LastModifyDate = DateTime.Now;
            FrequencyOfChange = ChangeFrequency.Always;
            Priority = 0.5m;
        }

        public string Url { get; private set; }
        public DateTime LastModifyDate { get; private set; }
        public ChangeFrequency FrequencyOfChange { get; private set; }
        public decimal Priority { get; private set; }
    }
}