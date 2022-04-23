using System.Text.Json.Serialization;

namespace JobSearchApp.DTOs
{
    public class Job
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("company_name")]
        public string? CompanyName { get; set; }

        [JsonPropertyName("company_logo")]
        public string? CompanyLogo { get; set; }

        [JsonPropertyName("category")]
        public string? Category { get; set; }

        [JsonPropertyName("job_type")]
        public string? JobType { get; set; }

        [JsonPropertyName("publication_date")]
        public DateTime PublicationDate { get; set; }

        [JsonPropertyName("candidate_required_location")]
        public string? CandidateRequiredLocation { get; set; }

        [JsonPropertyName("salary")]
        public string? Salary { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}
