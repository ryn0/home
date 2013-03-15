﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using RMW.Models;

namespace RMW
{
    public partial class Sitemap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string domainRoot = "http://ryanmichaelwilliams.com";

            Response.Clear();
            Response.ContentType = "text/xml";

            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);

            writer.WriteStartDocument();
            writer.WriteStartElement("urlset");
            writer.WriteAttributeString("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");
            writer.WriteString("\r\n");    

            // home
            writer.WriteStartElement("url");
            writer.WriteElementString("loc", domainRoot);
            writer.WriteElementString("lastmod", String.Format(CultureInfo.InvariantCulture, "{0:yyyy-MM-dd}", DateTime.UtcNow));
            writer.WriteElementString("changefreq", "weekly");
            writer.WriteElementString("priority", "1.0");
            writer.WriteEndElement();
            writer.WriteString("\r\n");

            // about
            writer.WriteStartElement("url");
            writer.WriteElementString("loc", string.Format(CultureInfo.InvariantCulture, "{0}/home/about", domainRoot));
            writer.WriteElementString("lastmod", String.Format(CultureInfo.InvariantCulture, "{0:yyyy-MM-dd}", DateTime.UtcNow));
            writer.WriteElementString("changefreq", "weekly");
            writer.WriteElementString("priority", "1.0");
            writer.WriteEndElement();
            writer.WriteString("\r\n");

            // portfolio
            writer.WriteStartElement("url");
            writer.WriteElementString("loc", string.Format(CultureInfo.InvariantCulture, "{0}/home/portfolio", domainRoot));
            writer.WriteElementString("lastmod", String.Format(CultureInfo.InvariantCulture, "{0:yyyy-MM-dd}", DateTime.UtcNow));
            writer.WriteElementString("changefreq", "weekly");
            writer.WriteElementString("priority", "1.0");
            writer.WriteEndElement();
            writer.WriteString("\r\n");

            // resume
            writer.WriteStartElement("url");
            writer.WriteElementString("loc", string.Format(CultureInfo.InvariantCulture, "{0}/home/resume", domainRoot));
            writer.WriteElementString("lastmod", String.Format(CultureInfo.InvariantCulture, "{0:yyyy-MM-dd}", DateTime.UtcNow));
            writer.WriteElementString("changefreq", "weekly");
            writer.WriteElementString("priority", "1.0");
            writer.WriteEndElement();
            writer.WriteString("\r\n");  

            // articles root
            writer.WriteStartElement("url");
            writer.WriteElementString("loc", string.Format(CultureInfo.InvariantCulture, "{0}/articles", domainRoot));
            writer.WriteElementString("lastmod", String.Format(CultureInfo.InvariantCulture, "{0:yyyy-MM-dd}", DateTime.UtcNow));
            writer.WriteElementString("changefreq", "weekly");
            writer.WriteElementString("priority", "1.0");
            writer.WriteEndElement();
            writer.WriteString("\r\n");

            // articles
            ArticleRepository articles = new ArticleRepository();
 
            foreach (Article ar1 in articles.All)
            {
                writer.WriteStartElement("url");
                writer.WriteElementString("loc", string.Format(CultureInfo.InvariantCulture, "{0}{1}", domainRoot, ar1.URLTo));
                writer.WriteElementString("lastmod", String.Format(CultureInfo.InvariantCulture, "{0:yyyy-MM-dd}", ar1.CreatedOn));
                writer.WriteElementString("changefreq", "weekly");
                writer.WriteElementString("priority", "0.8");
                writer.WriteEndElement();
                writer.WriteString("\r\n");     
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();

            Response.End();
        }
    }
}