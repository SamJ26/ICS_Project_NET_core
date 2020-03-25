using System;
using Microsoft.EntityFrameworkCore;

namespace FilmManagment.DAL.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        public DbContext WorkingDbContext { get; }

        public UnitOfWork(DbContext dbContext)
        {
            WorkingDbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Dispose() => WorkingDbContext.Dispose();

        public void Commit() => WorkingDbContext.SaveChanges();

    }
}
