using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using AngleSharp.Dom;
using AngleSharp.Text;
using HtmlAgilityPack;
using SocialAnalyzer.models;
using ConsoleApp8;
using SocialNetworkAnalyzer.Services.TikTok;
using OpenAI_API;

namespace ConsoleApp8
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var question = "dog";
            Console.WriteLine(UseChatGPT(question).Result);
            Console.WriteLine("Hello word");
        }
        
        public static async Task<string> UseChatGPT(string question)
        {
            var api = new OpenAIAPI("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");

            var chat = api.Chat.CreateConversation();

            chat.AppendSystemMessage("Ти викладач молодших класів в школі, твоя задача навчити дітей розріняти що з названого тварина а що ні," +
                "                     ти маєш відповідати виключно так або ні");
            chat.AppendUserInput("Boat");
            chat.AppendExampleChatbotOutput("no");
            chat.AppendUserInput("Cat");
            chat.AppendExampleChatbotOutput("Yes");

            chat.AppendUserInput(question);
            string response = await chat.GetResponseFromChatbotAsync();
            return response;
        }
    }
}
