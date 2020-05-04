using System;
using System.Windows;
using FilmManagment.GUI.Services;
using FilmManagment.GUI.Services.WarningMessageService;
using FilmManagment.GUI.ViewModels;
using FilmManagment.GUI.ViewModels.Interfaces;
using FilmManagment.GUI.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FilmManagment.BL.Facades;
using FilmManagment.BL.Repositories;
using FilmManagment.DAL.UnitOfWork;
using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Factories;
using FilmManagment.DAL;
using Microsoft.EntityFrameworkCore;
using FilmManagment.BL.Mappers;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Models.ListModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FilmManagment.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;

        public App()
        {
            host = new HostBuilder().ConfigureAppConfiguration((context, configurationBuilder) =>
                                    {
                                        configurationBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);
                                        configurationBuilder.AddJsonFile(@"AppSettings.json", false, true);
                                    })
                                    .ConfigureServices((context, services) => { ConfigureServicesToContainer(context.Configuration, services); })
                                    .Build();
        }

        private void ConfigureServicesToContainer(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainViewModel>();

            services.AddSingleton<IMediator, Mediator>();

            services.AddSingleton<IWarningViewModel, WarningViewModel>();
            services.AddSingleton<IWarningService, WarningService>();

            services.AddSingleton<IHomeViewModel, HomeViewModel>();
            services.AddSingleton<IFilmListViewModel, FilmListViewModel>();
            services.AddSingleton<IActorListViewModel, ActorListViewModel>();
            services.AddSingleton<IDirectorListViewModel, DirectorListViewModel>();

            services.AddSingleton<IFilmDetailViewModel, FilmDetailViewModel>();
            services.AddSingleton<IActorDetailViewModel, ActorDetailViewModel>();
            services.AddSingleton<IDirectorDetailViewModel, DirectorDetailViewModel>();

            services.AddSingleton<IMapper<FilmEntity, FilmListModel, FilmDetailModel>, FilmMapper>();
            services.AddSingleton<IMapper<ActorEntity, ActorListModel, ActorDetailModel>, ActorMapper>();
            services.AddSingleton<IMapper<DirectorEntity, DirectorListModel, DirectorDetailModel>, DirectorMapper>();

            services.AddSingleton<IEntityFactory, EntityFactory>();

            services.AddTransient<ActorFacade>();
            services.AddTransient<FilmFacade>();
            services.AddTransient<DirectorFacade>();
            services.AddTransient<RatingFacade>();

            services.AddTransient<Repository<FilmEntity>>();
            services.AddTransient<Repository<ActorEntity>>();
            services.AddTransient<Repository<DirectorEntity>>();
            services.AddTransient<Repository<RatingEntity>>();

            services.AddSingleton<UnitOfWork>();

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IDbContextFactory<AppDbContext>>(provider => new DbContextFactory(configuration.GetConnectionString("DefaultConnection")));
        }

        private async void Application_start(object sender, StartupEventArgs args)
        {
            await host.StartAsync();

            var mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private async void Application_exit(object sender, ExitEventArgs args)
        {
            using (host)
            {
                await host.StopAsync(TimeSpan.FromSeconds(2));
            }
        }
    }
}
