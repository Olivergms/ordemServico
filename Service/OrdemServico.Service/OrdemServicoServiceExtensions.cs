using Microsoft.Extensions.DependencyInjection;
using OrdemServico.Infra.Database.Services;
using OrdemServico.Service.Services;

namespace OrdemServico.Service
{
    public static class OrdemServicoServiceExtensions
    {
        public static void AddOrdemServicoServiceModule(this IServiceCollection services)
        {
            services.AddScoped<ISetorService, SetorService>();
        }
    }
}
