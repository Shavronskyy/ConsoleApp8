using AngleSharp.Text;
using HtmlAgilityPack;
using SocialAnalyzer.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetworkAnalyzer.Services.TikTok
{
    public class GetVideoInfo
    {
        public static TikTokVideo GetVideoStats(List<string> links)
        {
            TikTokVideo video = new TikTokVideo();

            List<int> likes = new List<int>();
            List<int> comments = new List<int>();
            List<int> shares = new List<int>();
            foreach(string link in links)
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(link);
                //likes
                var like = doc.DocumentNode.SelectSingleNode(".//button[@class='tiktok-nmbm7z-ButtonActionItem edu4zum0']//strong[@data-e2e='like-count']").InnerText;
                if (like[like.Length - 1] == 'K')
                {
                    likes.Add(HaveKEnding(like));
                } else if (like[like.Length - 1] == 'M')
                {
                    likes.Add(HaveMEnding(like));
                }
                else likes.Add(Convert.ToInt32(like));
                //comments
                var comment = doc.DocumentNode.SelectSingleNode(".//button[@class='tiktok-nmbm7z-ButtonActionItem edu4zum0']//strong[@data-e2e='comment-count']").InnerText;
                if (comment[comment.Length - 1] == 'K')
                {
                    comments.Add(HaveKEnding(comment));
                } else if (comment[comment.Length - 1] == 'M')
                {
                    comments.Add(HaveMEnding(comment));
                }
                else comments.Add(Convert.ToInt32(comment));
                //shares
                var share = doc.DocumentNode.SelectSingleNode(".//button[@class='tiktok-nmbm7z-ButtonActionItem edu4zum0']//strong[@data-e2e='share-count']").InnerText;
                if (share[share.Length - 1] == 'K')
                {
                    shares.Add(HaveKEnding(share));
                }
                else if (share[share.Length - 1] == 'M')
                {
                    shares.Add(HaveMEnding(share));
                }
                else if (share[0].IsDigit())
                {
                    shares.Add(Convert.ToInt32(share));
                }
                else shares.Add(0);
            }
            video.LikesCount = (int)likes.Average();
            video.SharesCount = (int)shares.Average();
            video.CommentsCount = (int)comments.Average();
            return video;
        }
        public static int HaveKEnding(string likes)
        {
            int num;
            bool containDot = true;
            if (!likes.Contains('.'))
            {
                containDot = true;
            }
            if (int.TryParse(likes.Replace(".", "").Replace("K", ""), out num))
            {
                num = containDot ? num *= 100 : num *= 1000;
            }
            return num;
        }
        public static int HaveMEnding(string views)
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
