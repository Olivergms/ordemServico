using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrdemServico.Domain.Repositories;
using OrdemServico.Infra.Database.Context;
using OrdemServico.Infra.Database.Repositories;

namespace OrdemServico.Infra.Database
{
    public static class OrdemServicoDatabaseExtensions
    {
        public static void AddOrdemServicoDatabaseServiceModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyContext>(
                op => op.UseNpgsql(configuration["ConnectionStrings:WebApiDatabase"]));


            services.AddScoped<ISetorRepository, SetorRepository>();
        }
    }
}
