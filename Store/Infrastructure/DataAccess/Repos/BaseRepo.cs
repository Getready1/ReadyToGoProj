using Store.Infrastructure.DataAccess.Repos.Interfaces;
using Store.Infrastructure.DomainModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Store.Infrastructure.DataAccess;

namespace Store.DataAccess.Repos
{
	public class BaseRepo<T> : IBaseRepo<T>, IBaseRepoAsync<T> where T : BaseEntity
	{
		protected DbCtx ctx;
		private DbSet<T> dbSet;

		public BaseRepo(DbCtx ctx)
		{
			this.ctx = ctx;
			dbSet = ctx.Set<T>();
		}

		public void Delete(T entity)
		{
			dbSet.Remove(entity);
			ctx.SaveChanges();
		}

		public async Task DeleteAsync(T entity)
		{
			dbSet.Remove(entity);
			await ctx.SaveChangesAsync();
		}

		public T GetById(int id) => dbSet.Find(id);

		public async Task<T> GetByIdAsync(int id) => await dbSet.FindAsync();

		public void Inert(T entity)
		{
			dbSet.Add(entity);
			ctx.SaveChanges();
		}

		public async Task InertAsync(T entity)
		{
			dbSet.Add(entity);
			await ctx.SaveChangesAsync();
		}

		public List<T> ListAll() => dbSet.ToList();

		public async Task<List<T>> ListAllAsync() => await dbSet.ToListAsync();

		public void Update(T entity)
		{
			ctx.Entry(entity).State = EntityState.Modified;
			ctx.SaveChanges();
		}

		public async Task UpdateAsync(T entity)
		{
			ctx.Entry(entity).State = EntityState.Modified;
			await ctx.SaveChangesAsync();
		}
	}
}