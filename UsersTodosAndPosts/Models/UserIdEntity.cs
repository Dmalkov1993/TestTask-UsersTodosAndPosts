using System.Text.Json.Serialization;

namespace UsersTodosAndPosts.Models
{
    public class UserIdEntity
    {
        [JsonPropertyName("userId")]
        public long UserId { get; set; }
    }
}
