using BuildingBlocks.Infrastructure.Database;
using Members.API.Public;
using Members.Core.Domain.RepositoryInterfaces;
using Members.Core.Mappers;
using Members.Core.UseCases;
using Members.Infrastructure.Authentification;
using Members.Infrastructure.Database;
using Members.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Infrastructure
{
    public static class MembersStartup
    {
        public static IServiceCollection ConfigureMembersModule(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MembersProfile));
            SetupCore(services);
            SetupInfrastructure(services);
            return services;
        }

        private static void SetupCore(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITokenGenerator, JwtGenerator>();
        }
        private static void SetupInfrastructure(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddDbContext<MembersContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("members"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "members")));
        }
    }
}
