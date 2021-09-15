using System.Text.Json.Serialization;

namespace UsersTodosAndPosts.Models
{
    public class Todo : UserIdEntity
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("completed")]
        public bool Completed { get; set; }
    }
}
