using MyP.BL.Abstract;
using MyP.BL.Concrete;
using MyP.DAL.Abstract;
using MyP.DAL.EntityFramework;

namespace MyP.BL.Container
{
	public static class Extensions
	{
		public static void ContainerDependencies(this IServiceCollection services)
		{
			services.AddScoped<IAboutService, AboutManager>();
			services.AddScoped<IAboutDal, EfAboutDal>();

			services.AddScoped<IContactService, ContactManager>();
			services.AddScoped<IContactDal, EfContactDal>();

			services.AddScoped<IExperienceService, ExperienceManager>();
			services.AddScoped<IExperienceDal, EfExperienceDal>();

			services.AddScoped<IFeatureService, FeatureManager>();
			services.AddScoped<IFeatureDal, EfFeatureDal>();

			services.AddScoped<IMessageService, MessageManager>();
			services.AddScoped<IMessageDal, EfMessageDal>();

			services.AddScoped<IPortfolioService, PortfolioManager>();
			services.AddScoped<IPortfolioDal, EfPortfolioDal>();

			services.AddScoped<ISkillService, SkillManager>();
			services.AddScoped<ISkillDal, EfSkillDal>();

			services.AddScoped<ISocialMediaService, SocialMediaManager>();
			services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

			services.AddScoped<ITestimonialService, TestimonialManager>();
			services.AddScoped<ITestimonialDal, EfTestimonialDal>();

			services.AddScoped<IToDoListService, ToDoListManager>();
			services.AddScoped<IToDoListDal, EfToDoListDal>();
		}
	}
}
