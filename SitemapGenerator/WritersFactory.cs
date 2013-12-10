using System;
using System.Linq;
using System.IO;
using SitemapGenerator.Url;
using SitemapGenerator.Writers;

namespace SitemapGenerator
{
    public static class StreaWritersFactory
    {
        public static IUrlWriter<TUrl> CreateWriter<TUrl>(Stream stream, string rootUrl) where TUrl : IUrl
        {
           
            if (typeof(TUrl) == typeof(ISitemapUrl))
            {
                return (IUrlWriter<TUrl>)(new SitemapStreamWriter(stream, rootUrl));
            }

            if (typeof(TUrl) == typeof(IIndexUrl))
            {
                return (IUrlWriter<TUrl>)(new IndexStreamWriter(stream, rootUrl));
            }

            throw new ArgumentException("Could not found StreamWriter for type " + typeof(TUrl));
        }

        //public static IUrlWriter<TUrl> CreateWriter<TUrl>(Stream stream, string rootUrl) where TUrl : IUrl
        //{
        //    var interfaces = typeof (TUrl).GetInterfaces();

        //    if (interfaces.Contains(typeof(ISitemapUrl)))
        //    {
        //        return (IUrlWriter<TUrl>)(new SitemapStreamWriter(stream, rootUrl));
        //    }

        //    if (interfaces.Contains(typeof(IIndexUrl)))
        //    {
        //        return (IUrlWriter<TUrl>)(new IndexStreamWriter(stream, rootUrl));
        //    }

        //    throw new ArgumentException("Could not found StreamWriter for type " + typeof(TUrl));
        //}
    }
}
