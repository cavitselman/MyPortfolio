using MyP.BL.Abstract;
using MyP.DAL.Abstract;
using MyP.DAL.Entities;

namespace MyP.BL.Concrete
{
	public class FeatureManager : IFeatureService
	{
		IFeatureDal _featureDal;

		public FeatureManager(IFeatureDal featureDal)
		{
			_featureDal = featureDal;
		}

		public void TAdd(Feature t)
		{
			_featureDal.Insert(t);
		}

		public void TDelete(Feature t)
		{
			_featureDal.Delete(t);
		}

		public Feature TGetByID(int id)
		{
			return _featureDal.GetByID(id);
		}

		public List<Feature> TGetList()
		{
			return _featureDal.GetList();
		}

		public void TUpdate(Feature t)
		{
			_featureDal.Update(t);
		}
	}
}
