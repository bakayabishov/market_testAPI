using aspnetcore.ntier.DAL.Repositories;
using aspnetcore.ntier.DAL.Repositories.IRepositories;
using DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DependencyInjection
{
    public static void DataAccessDependencies(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        });
    }
}