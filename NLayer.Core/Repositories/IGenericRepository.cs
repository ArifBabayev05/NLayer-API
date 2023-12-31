﻿using System;
using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
	public interface IGenericRepository<T> where T : class
	{

        IQueryable<T> GetAll();


        Task<T> GetByIdAsync(int id);

		//productRepo.where(x=>x.Id>5).OrderBy()...
		// Provides using another filters on method. 	
		IQueryable<T> Where(Expression<Func<T,bool>> expression);

		// Check if there is exist or not
		Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);

		Task AddRangeAsync(IEnumerable<T> entities);

		void Update(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

    }
}

