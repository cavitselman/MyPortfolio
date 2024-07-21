using Microsoft.EntityFrameworkCore;
using MyP.DAL.Context;
using MyP.DAL.Entities;

namespace MyP.BL.Abstract
{
	public interface IMessageService : IGenericService<Message>
	{
    }
}
