using MyP.BL.Abstract;
using MyP.DAL.Abstract;
using MyP.DAL.Entities;

namespace MyP.BL.Concrete
{
	public class AboutManager : IAboutService
	{
		IAboutDal _aboutDal;

		public AboutManager(IAboutDal aboutDal)
		{
			_aboutDal = aboutDal;
		}

		public void TAdd(About t)
		{
			_aboutDal.Insert(t);
		}

		public void TDelete(About t)
		{
			_aboutDal.Delete(t);
		}

		public About TGetByID(int id)
		{
			return _aboutDal.GetByID(id);
		}

		public List<About> TGetList()
		{
			return _aboutDal.GetList();
		}

		public void TUpdate(About t)
		{
			_aboutDal.Update(t);
		}
	}
}
