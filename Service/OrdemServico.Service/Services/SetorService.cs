
using OrdemServico.Domain.Dtos.Http;
using OrdemServico.Domain.Dtos.Http.Request;
using OrdemServico.Domain.Entities;
using OrdemServico.Domain.Repositories;
using OrdemServico.Infra.Database.Services;

namespace OrdemServico.Service.Services
{
    public class SetorService : ISetorService
    {
		private readonly ISetorRepository _setorRepository;

        public SetorService(ISetorRepository setorRepository)
        {
            _setorRepository = setorRepository;
        }

        public async Task CreateSetor(RequestCreateSetor dto)
        {
			try
			{
                var setor = new Setor() { Nome = dto.Nome };
                await _setorRepository.InsertAsync(setor);

			}
			catch (Exception ex)
			{

				throw;
			}
        }

        public async Task<ServerHttpResponse<IEnumerable<Setor>>> FindAll()
        {
            var response = new ServerHttpResponse<IEnumerable<Setor>>();
            try
            {
                var setorList = await _setorRepository.FindAll();


                response.Success = true;
                response.Content = setorList;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;


                throw;
            }

            return response;
        }
    }
}
