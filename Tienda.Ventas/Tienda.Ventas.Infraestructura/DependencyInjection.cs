using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Ventas.Applicacion.Persistence;
using Tienda.Ventas.Applicacion.Persistence.Repository;
using Tienda.Ventas.Infraestructura.Persistence;
using Tienda.Ventas.Infraestructura.Persistence.Repository;

namespace Tienda.Ventas.Infraestructura
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, IConfiguration configuration
            )
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(
                   configuration.GetConnectionString("DBConnectionString"),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IVentaRepository, VentaRepository>();

            return services;
        }
    }
}
