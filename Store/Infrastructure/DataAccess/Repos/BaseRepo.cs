using Store.Infrastructure.DataAccess.Repos.Interfaces;
using Store.Infrastructure.DomainModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Store.Infrastructure.DataAccess;
using System;
using System.Linq.Expressions;

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

		public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
		{
			IQueryable<T> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (!string.IsNullOrWhiteSpace(includeProperties))
			{
				foreach (var includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProperty);
				}
			}

			return orderBy != null ? orderBy(query).ToList() : query.ToList();
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