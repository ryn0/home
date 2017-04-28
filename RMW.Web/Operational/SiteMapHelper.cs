﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RMW.Web.Operational
{
    public class SiteMapHelper
    {
        public List<SiteMapItem> SiteMapItems { get; set; } = new List<SiteMapItem>();

        public void AddUrl(string url, DateTime lastMod, ChangeFrequency changeFrequency, double priority)
        {
            SiteMapItems.Add(new SiteMapItem
            {
                Url = url,
                LastMode = lastMod,
                ChangeFrequency = changeFrequency,
                Priority = priority
            });
        }

        public string GenerateXml()
        {

            var sb = new StringBuilder();
            sb.Append(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
            sb.AppendLine(@"<urlset xmlns=""http://www.sitemaps.org/schemas/sitemap/0.9"">");

            foreach (var siteMapItem in SiteMapItems)
            {
                sb.AppendLine(@"<url>");
                sb.AppendFormat(@"<loc>{0}</loc>", siteMapItem.Url);
                sb.AppendFormat(@"<lastmod>{0}</lastmod>", siteMapItem.LastMode.ToString("yyyy-MM-dd"));
                sb.AppendFormat(@"<changefreq>{0}</changefreq>", siteMapItem.ChangeFrequency.ToString());
                sb.AppendFormat(@"<priority>{0}</priority>", Math.Round(siteMapItem.Priority, 2));
                sb.AppendLine(@"</url>");
            }

            sb.AppendLine(@"</urlset>");

            return sb.ToString();
        }
    }

    public class SiteMapItem
    {
        public string Url { get; set; }

        public DateTime LastMode { get; set; }

        public ChangeFrequency ChangeFrequency { get; set; }

        public double Priority { get; set; }
    }

    public enum ChangeFrequency
    {
        Unknown = 0,
        never = 1,
        yearly = 2,
        monthly = 3,
        weekly = 4,
        daily = 5,
        hourly = 6,
        always = 7
    }
}