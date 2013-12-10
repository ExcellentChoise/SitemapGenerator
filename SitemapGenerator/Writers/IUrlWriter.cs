using System;

namespace SitemapGenerator.Writers
{
    public interface IUrlWriter<TUrl> : IDisposable
    {
        void WriteLocation(TUrl sitemapUrl);
        long GetTotalEstimatedBytes();
    }
}