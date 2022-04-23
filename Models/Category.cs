namespace JobSearchApp.Models
{
    public class DocumentCategory
    {
        public DocumentCategory()
        {
            Documents = new HashSet<Document>();
        }

        public int ID { get; set; }

        public string Category { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }

        public ICollection<Document> Documents { get; set; }
    }
}
