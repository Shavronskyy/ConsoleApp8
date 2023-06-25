using AngleSharp.Css;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SocialNetworkAnalyzer.Services.TikTok
{
    public class GetVideoUrl
    {
        public static List<string> GetLink(string url)
        {
            List<string> links = new List<string>();
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(url);
                var videoNodes = doc.DocumentNode.SelectNodes("//a[contains(@a, '/video/')]");

                if (videoNodes != null)
                {
                    foreach (var videoNode in videoNodes)
                    {
                        string videoUrl = "https://www.tiktok.com" + videoNode.Attributes["a"].Value;
                        links.Add(videoUrl);
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return links;
        }
    }
}
