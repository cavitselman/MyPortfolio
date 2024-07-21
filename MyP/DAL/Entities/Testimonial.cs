using System.ComponentModel.DataAnnotations;

namespace MyP.DAL.Entities
{
    public class Testimonial
    {
        [Key]
        public int TestimonialId { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
