using System.Text.Json.Serialization;

namespace EFGetStarted
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        [JsonIgnore] 
        public List<Post> Posts { get; } = new();
    }
}