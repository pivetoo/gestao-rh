using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using GestorRH.Dominio.Interfaces;
using GestorRH.Infrastructure.Repositories;
using GestorRH.Application.Services;
using GestorRH.Application.Interfaces;
using GestorRH.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestorRH.IoC.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<IBatidaPontoRepository, BatidaPontoRepository>();

            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IDepartamentoService, DepartamentoService>();
            services.AddScoped<ICargoService, CargoService>();
            services.AddScoped<IBatidaPontoService, BatidaPontoService>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConneciton"));
            });

            return services;
        }
    }
}
