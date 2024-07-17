using Microsoft.EntityFrameworkCore;
using MyP.DAL.Abstract;
using MyP.DAL.Context;
using MyP.DAL.Entities;

namespace MyP.BL.Abstract
{
	public interface IToDoListService : IGenericService<ToDoList>
	{
		public void ChangeToDoListStatusToTrue(int id)
		{
			MyPContext c = new MyPContext();
			var value = c.ToDoLists.Find(id);
			if (value != null)
			{
				value.Status = true;
				c.SaveChanges();
			}
		}

		public void ChangeToDoListStatusToFalse(int id)
		{
			MyPContext c = new MyPContext();
			var value = c.ToDoLists.Find(id);
			if (value != null)
			{
				value.Status = false;
				c.SaveChanges();
			}
		}
	}
}
