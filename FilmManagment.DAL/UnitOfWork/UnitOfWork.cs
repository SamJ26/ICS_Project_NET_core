using FilmManagment.DAL.Factories;
using Microsoft.EntityFrameworkCore;
using System;

namespace FilmManagment.DAL.UnitOfWork
{
	public class UnitOfWork : IDisposable
	{
		public DbContext DbContext { get; set; }

		public IDbContextFactory<AppDbContext> localDbContextFactory;

		public UnitOfWork(IDbContextFactory<AppDbContext> dbContextFactory)
		{
			localDbContextFactory = dbContextFactory;
		}

		public void Dispose() => DbContext.Dispose();

		public void Commit() => DbContext.SaveChanges();
	}
}
