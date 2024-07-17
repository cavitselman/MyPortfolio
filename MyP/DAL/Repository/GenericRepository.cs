using MyP.DAL.Abstract;
using MyP.DAL.Context;
using System.Linq.Expressions;

namespace MyP.DAL.Repository
{
	public class GenericRepository<T> : IGenericDal<T> where T : class
	{
		public void Delete(T t)
		{
			using var c = new MyPContext();
			c.Remove(t);
			c.SaveChanges();
		}

		public T GetByID(int id)
		{
			using var c = new MyPContext();
			return c.Set<T>().Find(id);
		}

		public List<T> GetList()
		{
			using var c = new MyPContext();
			return c.Set<T>().ToList();
		}

		public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
		{
			using var c = new MyPContext();
			return c.Set<T>().Where(filter).ToList();
		}

		public void Insert(T t)
		{
			using var c = new MyPContext();
			c.Add(t);
			c.SaveChanges();
		}

		public void Update(T t)
		{
			using var c = new MyPContext();
			c.Update(t);
			c.SaveChanges();
		}
	}
}
