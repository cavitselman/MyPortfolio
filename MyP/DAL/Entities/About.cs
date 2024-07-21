using System.ComponentModel.DataAnnotations;

namespace MyP.DAL.Entities
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string SubDescription { get; set; }
        public string Details { get; set; }
    }
}
