﻿using MyP.DAL.Abstract;
using MyP.DAL.Entities;
using MyP.DAL.Repository;

namespace MyP.DAL.EntityFramework
{
	public class EfExperienceDal : GenericRepository<Experience>, IExperienceDal
	{
	}
}
