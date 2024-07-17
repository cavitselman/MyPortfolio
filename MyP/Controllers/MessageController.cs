using Microsoft.AspNetCore.Mvc;
using MyP.BL.Abstract;
using MyP.DAL.Context;

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
	}
}
