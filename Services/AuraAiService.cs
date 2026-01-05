using System.Net.Http.Headers;
using System.Text.Json;

public class AuraAiService
{
    private readonly HttpClient _http;

    public AuraAiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<string> AskAura(string message)
    {
        _http.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", "YOUR_API_KEY");

        var body = new
        {
            model = "gpt-4.1-mini",
            messages = new[]
            {
                new { role = "system", content = "You are AURA, a calm but firm self-care and goal companion." },
                new { role = "user", content = message }
            }
        };

        var response = await _http.PostAsJsonAsync(
            "https://api.openai.com/v1/chat/completions", body);

        var json = await response.Content.ReadAsStringAsync();
        return JsonDocument.Parse(json)
            .RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString() ?? "";
    }
}
