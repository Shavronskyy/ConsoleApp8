using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class OpenAIApiClient
{
    private readonly HttpClient httpClient;
    private const string ApiUrl = "https://api.openai.com/v1/engines/davinci-codex/completions";

    public OpenAIApiClient()
    {
        httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer YOUR_API_KEY");
    }

    //public async Task<string> GetCompletion(string prompt)
    //{
    //    var requestData = new
    //    {
    //        prompt = prompt,
    //        max_tokens = 100
    //    };

    //    var content = new StringContent(
    //        //System.Text.Json.JsonSerializer.Serialize(requestData),
    //        Encoding.UTF8,
    //        "application/json"
    //    );

    //    var response = await httpClient.PostAsync(ApiUrl, content);
    //    response.EnsureSuccessStatusCode();

    //    var responseBody = await response.Content.ReadAsStringAsync();

    //    return responseBody;
    //}
}