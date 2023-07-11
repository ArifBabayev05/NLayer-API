using System;
using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
	public interface IGenericRepository<T> where T : class
	{
		Task<T> GetByIdAsync(int id);

		//productRepo.where(x=>x.Id>5).OrderBy()...
		// Provides using another filters on method. 	
		IQueryable<T> Where(Expression<Func<T,bool>> expression);

		// Check if there is exist or not
		Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task<T> AddAsync();

		void UpdateAsync(int id);
	}
}

