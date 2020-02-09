using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MasterMind.Data
{
    public class WikipediaService
    {
        private const string queryUri = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&titles=Mastermind%20(board%20game)&redirects=true";

        public async Task<WikipediaPage> GetMastermindArticleAsync()
        {
            var client = new HttpClient();
            HttpResponseMessage result = await client.GetAsync(queryUri);
            result.EnsureSuccessStatusCode();
            var serializedResult = await result.Content.ReadAsStringAsync();
            WikipediaResult wikiResult = JsonSerializer.Deserialize<WikipediaResult>(serializedResult);
            return wikiResult.query.pages;
        }
    }

    public class WikipediaResult
    {
        public string batchcomplete { get; set; }
        public WikipediaQuery query { get; set; }
    }

    public class WikipediaQuery
    {
        public WikipediaPage pages { get; set; }
    }

    public class WikipediaPage
    {
        [JsonPropertyName("231150")]
        public Wikipedia231150 page231150 { get; set; }
    }

    public class Wikipedia231150
    {
        public int pageid { get; set; }
        public int bs { get; set; }
        public string title { get; set; }
        public string extract { get; set; }
    }
}
