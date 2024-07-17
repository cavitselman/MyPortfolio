using MyP.BL.Abstract;
using MyP.DAL.Abstract;
using MyP.DAL.Entities;

namespace MyP.BL.Concrete
{
	public class SocialMediaManager : ISocialMediaService
	{
		ISocialMediaDal _socialMediaDal;

		public SocialMediaManager(ISocialMediaDal socialMediaDal)
		{
			_socialMediaDal = socialMediaDal;
		}

		public void TAdd(SocialMedia t)
		{
			_socialMediaDal.Insert(t);
		}

		public void TDelete(SocialMedia t)
		{
			_socialMediaDal.Delete(t);
		}

		public SocialMedia TGetByID(int id)
		{
			return _socialMediaDal.GetByID(id);
		}

		public List<SocialMedia> TGetList()
		{
			return _socialMediaDal.GetList();
		}

		public void TUpdate(SocialMedia t)
		{
			_socialMediaDal.Update(t);
		}
	}
}
