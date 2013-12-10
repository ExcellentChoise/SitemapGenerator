using SitemapGenerator.Url;

namespace SitemapGenerator
{
    public interface ISitemapGenerator
    {
        void Start();
        void Stop();
        void AddUrl(ISitemapUrl url);
    }
}