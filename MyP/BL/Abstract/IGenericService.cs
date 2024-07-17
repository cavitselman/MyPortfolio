namespace MyP.BL.Abstract
{
	public interface IGenericService<T>
	{
		void TAdd(T t);
		void TDelete(T t);
		void TUpdate(T t);
		List<T> TGetList();
		T TGetByID(int id);
	}
}
