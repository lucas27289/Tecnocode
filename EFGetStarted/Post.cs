namespace EFGetStarted
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

// para relacion m2m con tags
        public ICollection<Tag> Tags { get; set; } 
    }
}