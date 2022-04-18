namespace JobSearchApp.Models
{
    public class DocumentType
    {
        public DocumentType()
        {
            Documents = new HashSet<Document>();
        }

        public int ID { get; set; }
        public string Type { get; set; }

        //O:M Relationships

        public ICollection<Document> Documents { get; set; }
    }
}
