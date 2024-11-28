using System.Text.Json.Serialization;

namespace challenge.Models
{
    public class GitHubRepo
    {
        public String Name { get; set; }
        public String Description { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt {get; set; }
    }
}
