using Microsoft.AspNetCore.Mvc;
using OrdemServico.Domain.Dtos.Http;
using OrdemServico.Domain.Dtos.Http.Request;
using OrdemServico.Domain.Entities;
using OrdemServico.Infra.Database.Services;

namespace OrdemServico.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SetorController : ControllerBase
    {
        private readonly ISetorService _service;

        public SetorController(ISetorService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServerHttpResponse<IEnumerable<Setor>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServerHttpResponse<IEnumerable<Setor>>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ServerHttpResponse<IEnumerable<Setor>>>> Get() 
        {
            try
            {
                var response = await _service.FindAll();
                if (!response.Success) return UnprocessableEntity(response);
                return Ok(response);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody]RequestCreateSetor dto)
        {
            try
            {
                await _service.CreateSetor(dto);
                return Created();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
