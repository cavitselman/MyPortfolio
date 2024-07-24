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

        public IActionResult ReplyMessage(int messageId)
        {
            MyPContext c = new MyPContext();
            ViewBag.v1 = c.AdminReplys.Where(x => x.Id == messageId).ToList();
            ViewBag.v2 = c.AdminReplys.Select(x => x.Reply.ToList());
            ViewBag.v3 = c.AdminReplys.Select(x => x.Date).ToList();
            ViewBag.v4 = c.AdminReplys.Select(x => x.SenderEmail).ToList();
            return View(messageId);
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
			_messageService.TUpdate(value);
			return RedirectToAction("Inbox");
		}

		public IActionResult ChangeIsReadToFalse(int id)
		{
			var value = _messageService.TGetByID(id);
			value.IsRead = false;
			_messageService.TUpdate(value);
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
            using (var context = new MyPContext())
            {
                var sender = context.AdminReplys.Where(x => x.MessageId == id).Select(x => x.SenderEmail).FirstOrDefault();
                // Belirli bir id'ye sahip AdminReplys kaydının Reply özelliğini alıyoruz
                var reply = context.AdminReplys.Where(x => x.MessageId == id).Select(x => x.Reply).ToList();

                var replyDates = context.AdminReplys.Where(x => x.MessageId == id).OrderBy(x => x.Date).Select(x => x.Date).FirstOrDefault();

                // ViewBag.reply: Belirli id'ye sahip AdminReplys kaydının Reply özelliğini view'e aktarıyoruz
                ViewBag.reply = reply;
                ViewBag.date = replyDates;
                ViewBag.sender = sender;
            }
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
                    SenderEmail = "myportfolio@website.com", // Adminin e-posta adresi buraya gelmeli
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
