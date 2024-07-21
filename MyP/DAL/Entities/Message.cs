using System.ComponentModel.DataAnnotations;

namespace MyP.DAL.Entities
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string NameSurname { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string MessageDetail { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }

        public ICollection<AdminReply> AdminReplys { get; set; }
    }
}
