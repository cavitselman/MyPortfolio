using System.Linq.Expressions;

namespace MyP.DAL.Abstract
{
	public interface IGenericDal<T>
	{
		void Insert(T t);
		void Delete(T t);
		void Update(T t);
		List<T> GetList();
		T GetByID(int id);
	}
}
