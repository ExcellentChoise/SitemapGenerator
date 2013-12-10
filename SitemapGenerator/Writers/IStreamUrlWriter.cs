namespace SitemapGenerator.Writers
{
    public interface IStreamUrlWriter<TUrl> : IUrlWriter<TUrl>
    {
        void FinishWrite();
    }
}