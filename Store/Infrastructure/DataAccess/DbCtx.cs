using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Store.Infrastructure.DataAccess
{
	public class DbCtx : DbContext
	{
		public DbCtx() : base()
		{

		}
	}
}