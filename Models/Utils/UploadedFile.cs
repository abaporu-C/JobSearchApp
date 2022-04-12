using System.ComponentModel.DataAnnotations;

namespace JobSearchApp.Models.Utils
{
    public class UploadedFile
    {
        public UploadedFile()
        {
            FileContent = new FileContent();
        }
        public int ID { get; set; }

        [StringLength(255, ErrorMessage = "The name of the file cannot be more than 255 characters.")]
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        public FileContent FileContent { get; set; }
    }
}
