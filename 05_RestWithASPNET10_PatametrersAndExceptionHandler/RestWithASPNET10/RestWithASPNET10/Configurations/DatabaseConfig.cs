using Microsoft.EntityFrameworkCore;
using RestWithASPNET10.Model.Context;

namespace RestWithASPNET10.Configurations
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabaseConfiguration(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["MSSQLServerSQLConnection:MSSQLServerSQLConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("Connection string 'MSSQLServerSQLConnectionString' not found.");
            }

            services.AddDbContext<MSSQLContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }
    }
}
