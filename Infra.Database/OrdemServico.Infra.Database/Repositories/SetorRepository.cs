
using Microsoft.EntityFrameworkCore;
using OrdemServico.Domain.Entities;
using OrdemServico.Domain.Repositories;
using OrdemServico.Infra.Database.Context;

namespace OrdemServico.Infra.Database.Repositories
{
    public class SetorRepository : ISetorRepository
    {
        private readonly MyContext _db;

        public SetorRepository(MyContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<IEnumerable<Setor>> FindAll()
        {
            return await _db.Setores.AsNoTracking().ToListAsync();
        }

        public async Task InsertAsync(Setor setor)
        {
            await _db.AddAsync(setor);
            await _db.SaveChangesAsync();
        }
    }
}
