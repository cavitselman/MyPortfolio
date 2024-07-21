using System.ComponentModel.DataAnnotations;

namespace MyP.DAL.Entities
{
    public class Experience
    {
        [Key]
        public int ExperienceId { get; set; }
        public string Head { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}
