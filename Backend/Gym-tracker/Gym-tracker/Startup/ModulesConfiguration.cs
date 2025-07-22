using Members.Infrastructure;
using Training.Infrastructure;

namespace Gym_tracker.Startup
{
    public static class ModulesConfiguration
    {
        public static IServiceCollection RegisterModules(this IServiceCollection services)
        {
            services.ConfigureTrainingModule();
            services.ConfigureMembersModule();
            return services;
        }
    }
}
