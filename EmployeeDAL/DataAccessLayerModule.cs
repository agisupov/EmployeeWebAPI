using EmployeeDAL.Data;
using EmployeeShared;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDAL
{
    public class DataAccessLayerModule : IModule
    {
        private readonly IConfiguration _configuration;

        public DataAccessLayerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void RegisterDependencies(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
