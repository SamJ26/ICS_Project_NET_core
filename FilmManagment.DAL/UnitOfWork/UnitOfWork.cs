using FilmManagment.DAL.Factories;
using Microsoft.EntityFrameworkCore;
using System;

namespace FilmManagment.DAL.UnitOfWork
{
	public class UnitOfWork : IDisposable
	{
		public DbContext DbContext { get; set; }

		public IDbContextFactory<AppDbContext> localDbContextFactory;
		public EntityFactory usedEntityFactory;

		public UnitOfWork(IDbContextFactory<AppDbContext> dbContextFactory)
		{
			localDbContextFactory = dbContextFactory;
		}

		public UnitOfWork Create()
		{
			DbContext = localDbContextFactory.CreateDbContext();
			usedEntityFactory = new EntityFactory((AppDbContext)DbContext);
			return this;
		}

		public void Dispose() => DbContext.Dispose();

		public void Commit() => DbContext.SaveChanges();
	}
}
