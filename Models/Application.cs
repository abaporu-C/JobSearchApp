namespace JobSearchApp.Models
{
    public class Application
    {

        public Application()
        {
            ApplicationDocuments = new HashSet<ApplicationDocument>();
        }

        public int ID { get; set; }

        public string URL { get; set; }

        public string Category { get; set; }

        public string Employer { get; set; }

        public string JobTitle { get; set; }

        public bool HasApplied { get; set; }

        public DateTime? ApplicationDate { get; set; }

        public bool HasInterviewed { get; set; }

        public DateTime? InterviewDate { get; set; }

        public bool Hired { get; set; }

        public DateTime? HireDate { get; set; }

        public string Notes { get; set; }

        //Foreign Key
        public int UserID { get; set; }

        public User User { get; set; }

        //O:M Relationships
        public ICollection<ApplicationDocument> ApplicationDocuments { get; set; }
    }
}
