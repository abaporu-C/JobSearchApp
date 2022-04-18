namespace JobSearchApp.Models
{
    public class ApplicationDocument
    {

        //Foreign Keys

        public int ApplicationID { get; set; }

        public Application Application { get; set; }

        public int DocumentID { get; set; }

        public Document Document { get; set; }
    }
}
