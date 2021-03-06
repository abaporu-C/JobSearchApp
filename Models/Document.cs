using JobSearchApp.Models.Utils;

namespace JobSearchApp.Models
{
    public class Document : UploadedFile
    {

        public Document()
        {
            ApplicationDocuments = new HashSet<ApplicationDocument>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        //Foreign Keys

        public int UserID { get; set; }

        public User User { get; set; }

        public int DocumentCategoryID { get; set; }

        public DocumentCategory DocumentCategory { get; set; }
        
        //O:M Relationships

        public ICollection<ApplicationDocument> ApplicationDocuments { get; set; }
    }
}
