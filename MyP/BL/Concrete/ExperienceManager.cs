using MyP.BL.Abstract;
using MyP.DAL.Abstract;
using MyP.DAL.Entities;

namespace MyP.BL.Concrete
{
	public class ExperienceManager : IExperienceService
	{
		IExperienceDal _experienceDal;

		public ExperienceManager(IExperienceDal experienceDal)
		{
			_experienceDal = experienceDal;
		}

		public void TAdd(Experience t)
		{
			_experienceDal.Insert(t);			
		}

		public void TDelete(Experience t)
		{
			_experienceDal.Delete(t);
		}

		public Experience TGetByID(int id)
		{
			return _experienceDal.GetByID(id);
		}

		public List<Experience> TGetList()
		{
			return _experienceDal.GetList();
		}

		public void TUpdate(Experience t)
		{
			_experienceDal.Update(t);
		}
	}
}
