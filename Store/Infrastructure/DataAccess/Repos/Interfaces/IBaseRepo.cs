using Store.Infrastructure.DomainModels;
using System.Collections.Generic;

namespace Store.Infrastructure.DataAccess.Repos.Interfaces
{
	public interface IBaseRepo<T> where T: BaseEntity
	{
		List<T> ListAll();
		T GetById(int id);
		void Inert(T entity);
		void Delete(T entity);
		void Update(T entity);
	}
}