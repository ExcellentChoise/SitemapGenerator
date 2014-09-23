SitemapGenerator
================

A small lib for generation of huge sitemaps with index file.

Example of usage:

Setup some configuration variables:

    // optional parameters
    int maxUrlsCountAtSingleMap = 10000;
    int maxSitemapSizeBytes = 10 * 1024 * 1024; 
    string fileNamePattern = "sitemap{0}.xml"; // sitemap files will have names like sitemap0.xml, sitemap1.xml ...
    // required parameters
    string baseDirectory = "."; // directory where sitemap will be generated
    string indexFilePath = Path.Combine(baseDirectory, "sitemap_index"); 
    string rootUri = "http://www.mysite.com";
    
And use:

    using (IUrlWriter<IIndexUrl> indexWriter = new FileSitemapWriter<IIndexUrl>(indexFilePath, rootUri))
    {
      SitemapGeneratorBase generator = new SitemapGeneratorBase(rootUri, baseDirectory, indexWriter, fileNamePattern, maxSitemapSizeBytes, maxUrlsCountAtSingleMap);
      
      generator.Start();
      generator.AddUrl(new SitemapUrl("http://www.mysite.com/weather", ChangeFrequency.Monthly));
      // ...
      generator.Stop();    
    }
