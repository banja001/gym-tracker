using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Training.API.Public;
using Training.Core.Domain.RepositoryInterfaces;
using Training.Core.Mappers;
using Training.Core.UseCases;
using Training.Infrastructure.Database;
using Training.Infrastructure.Database.Repositories;
using BuildingBlocks.Infrastructure.Database;

namespace Training.Infrastructure
{
    public static class TrainingStartup
    {
        public static IServiceCollection ConfigureTrainingModule(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(TrainingProfile));
            SetupCore(services);
            SetupInfrastructure(services);
            return services;
        }
            
        private static void SetupCore(IServiceCollection services)
        {
            services.AddScoped<IWorkoutService, WorkoutService>();
        }
        private static void SetupInfrastructure(IServiceCollection services)
        {
            services.AddScoped<IWorkoutRepository, WorkoutRepository>();

            services.AddDbContext<TrainingContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("training"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "training")));
        }
    }
}
