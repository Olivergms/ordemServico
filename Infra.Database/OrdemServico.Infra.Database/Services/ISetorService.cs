
using OrdemServico.Domain.Dtos.Http;
using OrdemServico.Domain.Dtos.Http.Request;
using OrdemServico.Domain.Entities;

namespace OrdemServico.Infra.Database.Services
{
    public interface ISetorService
    {
        Task CreateSetor(RequestCreateSetor dto);
        Task<ServerHttpResponse<IEnumerable<Setor>>> FindAll();
    }
}
