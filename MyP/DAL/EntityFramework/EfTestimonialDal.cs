using MyP.DAL.Abstract;
using MyP.DAL.Entities;
using MyP.DAL.Repository;

namespace MyP.DAL.EntityFramework
{
	public class EfTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
	{
	}
}
