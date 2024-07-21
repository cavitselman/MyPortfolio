using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyP.DAL.Entities
{
    public class AdminReply
    {
        [Key]
        public int Id { get; set; }

        public int MessageId { get; set; } // Dış anahtar, Message ile ilişkili olan MessageId
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; } // Alıcı e-posta adresi

        public DateTime Date { get; set; }

        public string Reply { get; set; }

        // Message ile ilişkiyi tanımlamak için navigasyon özelliği
        [ForeignKey("MessageId")]
        public Message Message { get; set; }
    }
}
