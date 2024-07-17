using MyP.BL.Abstract;
using MyP.DAL.Abstract;
using MyP.DAL.Entities;

namespace MyP.BL.Concrete
{
	public class SkillManager : ISkillService
	{
		ISkillDal _skillDal;

		public SkillManager(ISkillDal skillDal)
		{
			_skillDal = skillDal;
		}

		public void TAdd(Skill t)
		{
			_skillDal.Insert(t);
		}

		public void TDelete(Skill t)
		{
			_skillDal.Delete(t);
		}

		public Skill TGetByID(int id)
		{
			return _skillDal.GetByID(id);
		}

		public List<Skill> TGetList()
		{
			return _skillDal.GetList();
		}

		public void TUpdate(Skill t)
		{
			_skillDal.Update(t);
		}
	}
}
