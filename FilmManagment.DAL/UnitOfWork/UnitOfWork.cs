using Microsoft.EntityFrameworkCore;
using System;

namespace FilmManagment.DAL.UnitOfWork
{
	public class UnitOfWork : IDisposable
	{
		public DbContext DbContext { get; set; }

		public UnitOfWork(AppDbContext dbContext)
		{
			DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
		}

		public void Dispose() => DbContext.Dispose();

		public void Commit() => DbContext.SaveChanges();
	}
}
