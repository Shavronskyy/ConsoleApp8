using AngleSharp.Css;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SocialNetworkAnalyzer.Services.TikTok
{
    public class AvgViews
    {
        public static int GetAvgViews(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            var videoViews = doc.DocumentNode.SelectNodes(".//strong[@data-e2e='video-views']");
            List<int> avgViewsCount = new List<int>();
            foreach (var views in videoViews)
            {
                string view = views.InnerText;
                if (view[view.Length - 1] == 'K')
                {
                    avgViewsCount.Add(ViewsHaveKEnding(view));
                }
                else if (view[view.Length - 1] == 'M')
                {
                    avgViewsCount.Add(ViewsHaveMEnding(view));
                }
                else avgViewsCount.Add(Convert.ToInt32(view));
            }  
            return (int)avgViewsCount.Average();
        }
        public static int ViewsHaveKEnding(string views)
        {
            int num;
            bool containDot = true;
            if (!views.Contains('.'))
            {
                containDot = true;
            }
            if (int.TryParse(views.Replace(".", "").Replace("K", ""), out num))
            {
                num = containDot ? num *= 100 : num *= 1000;
            }
            return num;
        }
        public static int ViewsHaveMEnding(string views)
        {
            int num;
            bool containDot = true;
            if (!views.Contains('.'))
            {
                containDot = true;
            }
            if (int.TryParse(views.Replace(".", "").Replace("M", ""), out num))
            {
                num = containDot ? num *= 100000 : num *= 1000000;
            }
            return num;
        }
    }
}
