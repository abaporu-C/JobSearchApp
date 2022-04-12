using JobSearchApp.Models.Utils;

namespace JobSearchApp.Models
{
    public class Document : UploadedFile
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int ApplicationID { get; set; }

        public Application Application { get; set; }

        public int DocumentTypeID { get; set; }

        public DocumentType DocumentType { get; set; }        
    }
}
