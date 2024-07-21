using Microsoft.AspNetCore.Mvc;
using MyP.BL.Abstract;
using MyP.DAL.Entities;

namespace MyP.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var values = _contactService.TGetByID(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateContact(Contact contact)
        {
            _contactService.TUpdate(contact);
            return Redirect("/Default/Index#contact");
        }
    }
}
