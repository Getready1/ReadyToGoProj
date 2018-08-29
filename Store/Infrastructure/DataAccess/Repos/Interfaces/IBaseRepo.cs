using Store.Infrastructure.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Store.Infrastructure.DataAccess.Repos.Interfaces
{
	public interface IBaseRepo<T> where T: BaseEntity
	{
		List<T> ListAll();
		T GetById(int id);
		void Inert(T entity);
		void Delete(T entity);
		void Update(T entity);
		IEnumerable<T> Get(
			Expression<Func<T, bool>> filter = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			string includeProperties = "");
	}
}