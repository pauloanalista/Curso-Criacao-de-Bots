using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Bot.Instagram.Profile
{
    public static class Instagram
    {
        public static Profile GetProfileByUser(string username)
        {
            var profile = new Profile(username);
            string url = @"https://www.instagram.com/" + username+ "/";
            string markup;
            using (WebClient c = new WebClient())
            {
                markup = c.DownloadString(url);
            }

            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(markup);

            var list = html.DocumentNode.SelectNodes("//meta");
            
            foreach (var node in list)
            {
                string property = node.GetAttributeValue("property", "");

                if (property == "al:ios:app_name")
                    profile.IosAppName = node.GetAttributeValue("content", "");

                if (property == "al:ios:app_store_id")
                    profile.IosAppId = node.GetAttributeValue("content", "");

                if (property == "al:ios:url")
                    profile.IosUrl = node.GetAttributeValue("content", "");

                if (property == "al:android:app_name")
                    profile.AndroidAppName = node.GetAttributeValue("content", "");

                if (property == "al:android:package")
                    profile.AndroidAppId = node.GetAttributeValue("content", "");

                if (property == "al:android:url")
                    profile.AndroidUrl = node.GetAttributeValue("content", "");


                if (property == "og:type")
                    profile.Type = node.GetAttributeValue("content", "");

                if (property == "og:image")
                    profile.Image = node.GetAttributeValue("content", "");

                if (property == "og:title")
                    profile.Title = node.GetAttributeValue("content", "");

                if (property == "og:description")
                    profile.Description = node.GetAttributeValue("content", "");

                if (property == "og:url")
                    profile.Url = node.GetAttributeValue("content", "");
            }

            return profile;
        }
    }
}
