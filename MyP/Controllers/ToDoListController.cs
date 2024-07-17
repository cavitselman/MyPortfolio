using Microsoft.AspNetCore.Mvc;
using MyP.BL.Abstract;
using MyP.DAL.Context;
using MyP.DAL.Entities;

namespace MyP.Controllers
{
	public class ToDoListController : Controller
	{	
		private readonly IToDoListService _toDoListService;

		public ToDoListController(IToDoListService toDoListService)
		{
			_toDoListService = toDoListService;
		}		

		public IActionResult Index()
		{
			var values = _toDoListService.TGetList();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateToDoList()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateToDoList(ToDoList toDoList)
		{
			toDoList.Status = false;
			_toDoListService.TAdd(toDoList);
			return RedirectToAction("Index");
		}

		public IActionResult DeleteToDoList(int id)
		{
			var value = _toDoListService.TGetByID(id);
			_toDoListService.TDelete(value);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult UpdateToDoList(int id)
		{
			var value = _toDoListService.TGetByID(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateToDoList(ToDoList toDoList)
		{
			_toDoListService.TUpdate(toDoList);
			return RedirectToAction("Index");
		}

		public IActionResult ChangeToDoListStatusToTrue(int id)
		{
			_toDoListService.ChangeToDoListStatusToTrue(id);
			return RedirectToAction("Index");
		}

		public IActionResult ChangeToDoListStatusToFalse(int id)
		{
			_toDoListService.ChangeToDoListStatusToFalse(id);
			return RedirectToAction("Index");
		}
	}
}
