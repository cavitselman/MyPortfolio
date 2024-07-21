using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyP.BL.Abstract;
using MyP.BL.Concrete;
using MyP.DAL.Context;
using MyP.DAL.Entities;
using MyP.Models;

namespace MyP.Controllers
{	
	public class MessageController : Controller
	{
		private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Inbox()
		{
			var values = _messageService.TGetList();
			return View(values);
		}
		public IActionResult ChangeIsReadToTrue(int id)
		{
			var value = _messageService.TGetByID(id);
			value.IsRead = true;
			return RedirectToAction("Inbox");
		}

		public IActionResult ChangeIsReadToFalse(int id)
		{
			var value = _messageService.TGetByID(id);
			value.IsRead = false;
			return RedirectToAction("Inbox");
		}

		public IActionResult DeleteMessage(int id)
		{
			var value = _messageService.TGetByID(id);
			_messageService.TDelete(value);
			return RedirectToAction("Inbox");
		}

		public IActionResult MessageDetail(int id)
		{
			var value = _messageService.TGetByID(id);
			return View(value);
		}

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            message.SendDate = DateTime.Now.ToLocalTime();
            message.IsRead = false;
            _messageService.TAdd(message);
            return Redirect("/Default/Index#contact");
        }

        [HttpPost]
        public IActionResult SendReply(int messageId, string replyContent)
        {
            try
            {
                // Mesajı bul
                var message = _messageService.TGetByID(messageId);

                if (message == null)
                {
                    return NotFound(); // Mesaj bulunamadıysa 404 döndür
                }

                // Admin cevabını oluştur
                var adminReply = new AdminReply
                {
                    MessageId = messageId,
                    SenderEmail = "myportfolio@gmail.com", // Adminin e-posta adresi buraya gelmeli
                    ReceiverEmail = message.Email, // Alıcı emaili Message modelinden al
                    Date = DateTime.Now,
                    Reply = replyContent
                };

                // Admin cevabını mesaja ekle
                message.AdminReplys ??= new List<AdminReply>(); // AdminReplies null ise yeni liste oluştur
                message.AdminReplys.Add(adminReply);

                using (var context = new MyPContext())
                {
                    context.AdminReplys.Add(adminReply);
                    context.SaveChanges();
                }

                TempData["SuccessMessage"] = "Cevabınız başarıyla gönderildi.";

                // Başarı mesajı ile birlikte, yönlendirme yap
                return RedirectToAction("MessageDetail", new { id = messageId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Cevap gönderirken bir hata oluştu: {ex.Message}";

                // Hata mesajı ile birlikte, yönlendirme yap
                return RedirectToAction("MessageDetail", new { id = messageId });
            }
        }
    }

}
