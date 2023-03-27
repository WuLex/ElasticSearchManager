namespace ElasticSearchManager.Models
{
    public class Document
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //public string Text { get; set; }
        public string Content { get; set; }

        public List<string> Tags { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Author Author { get; set; }

        public override string ToString()
        {
            return $"{Title} ({Id})";
        }
    }

    public class Author
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}