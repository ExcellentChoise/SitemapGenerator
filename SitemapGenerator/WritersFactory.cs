﻿using System;
using System.Linq;
using System.IO;
using SitemapGenerator.Url;
using SitemapGenerator.Writers;

namespace SitemapGenerator
{
    public static class StreaWritersFactory
    {
        public static IStreamUrlWriter<TUrl> CreateWriter<TUrl>(Stream stream, string rootUrl) where TUrl : IUrl
        {
           
            if (typeof(TUrl) == typeof(ISitemapUrl))
            {
                return (IStreamUrlWriter<TUrl>)(new SitemapStreamWriter(stream, rootUrl));
            }

            if (typeof(TUrl) == typeof(IIndexUrl))
            {
                return (IStreamUrlWriter<TUrl>)(new IndexStreamWriter(stream, rootUrl));
            }

            throw new ArgumentException("Could not found StreamWriter for type " + typeof(TUrl));
        }
    }
}
