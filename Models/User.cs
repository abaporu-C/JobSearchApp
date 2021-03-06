namespace JobSearchApp.Models
{
    public class User
    {
        public User()
        {
            Applications = new HashSet<Application>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime JoinedOn { get; set; }

        //O:M Relationships

        public ICollection<Application> Applications { get; set; }

        public ICollection<Document> Documents { get; set; }
    }
}
