using Store.Infrastructure.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Infrastructure.DataAccess.Repos.Interfaces
{
	public interface IBaseRepoAsync<T> where T: BaseEntity
	{
		Task<List<T>> ListAllAsync();
		Task<T> GetByIdAsync(int id);
		Task InertAsync(T entity);
		Task DeleteAsync(T entity);
		Task UpdateAsync(T entity);
	}
}