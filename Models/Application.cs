namespace JobSearchApp.Models
{
    public class Application
    {

        public Application()
        {
            Documents = new HashSet<Document>();
        }

        public int ID { get; set; }

        public string URL { get; set; }

        public string Employer { get; set; }

        public bool HasApplied { get; set; }

        public DateTime ApplicationDate { get; set; }

        public bool HasInterviewed { get; set; }

        public DateTime InterviewDate { get; set; }

        public bool Hired { get; set; }

        public DateTime HireDate { get; set; }

        public string Notes { get; set; }

        public ICollection<Document> Documents { get; set; }
    }
}
