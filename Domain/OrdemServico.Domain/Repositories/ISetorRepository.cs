
using OrdemServico.Domain.Entities;

namespace OrdemServico.Domain.Repositories
{
    public interface ISetorRepository
    {
        Task InsertAsync(Setor setor);
        Task<IEnumerable<Setor>> FindAll();
    }
}
