namespace SitemapGenerator.Url
{
    public interface ISitemapUrl : IUrl
    {
        ChangeFrequency FrequencyOfChange { get; }
        decimal Priority { get; }
    }
}