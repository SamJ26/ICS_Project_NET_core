using FilmManagment.BL.Repositories;
using FilmManagment.DAL.Entities;
using FilmManagment.DAL.UnitOfWork;
using System;

namespace FilmManagment.BL.Facades
{
	public class FilmActorFacade
	{
		private readonly UnitOfWork usedUnitOfWork;
		private readonly Repository<FilmActorEntity> repository;

		public FilmActorFacade(UnitOfWork aUnitOfWork,
							   Repository<FilmActorEntity> aRepository)
		{
			usedUnitOfWork = aUnitOfWork;
			repository = aRepository;
		}

		/// <summary>
		/// Method for removing connection between FilmEntity and ActorEntity
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
