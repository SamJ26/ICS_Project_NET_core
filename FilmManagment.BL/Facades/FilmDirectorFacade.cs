using FilmManagment.BL.Repositories;
using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Factories;
using FilmManagment.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;

namespace FilmManagment.BL.Facades
{
    public class FilmDirectorFacade
    {
        private readonly UnitOfWork usedUnitOfWork;
        private readonly Repository<FilmDirectorEntity> repository;

        public FilmDirectorFacade(UnitOfWork aUnitOfWork,
                                  Repository<FilmDirectorEntity> aRepository)
        {
            usedUnitOfWork = aUnitOfWork;
            repository = aRepository;
        }

        /// <summary>
        /// Method for removing connection between FilmEntity and DirectorEntity
        /// </summary>
        public void Delete(Guid id)
        {
            using (var unitOfWork = usedUnitOfWork.Create())
            {
                repository.DeleteById(id);
                usedUnitOfWork.Commit();
            }
        }
    }
}
