using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoModeloDDD.Domain.DTOs;
using ProjetoModeloDDD.Domain.DTOs.InputModels;
using ProjetoModeloDDD.Domain.DTOs.OutputModels;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResultViewModel<IEnumerable<PessoaOutputModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResultViewModel<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
            => Ok(await _pessoaService.ObterTodosAsync());

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResultViewModel<PessoaOutputModel>), (short)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResultViewModel<object>), (short)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get(int id)
            => Ok(await _pessoaService.ObterPorIdAsync(id));

        [HttpPost]
        [ProducesResponseType(typeof(ResultViewModel<bool>), (short)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResultViewModel<object>), (short)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] PessoaInputModel inputModel)
            => Ok(await _pessoaService.InsertAsync(inputModel));

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResultViewModel<bool>), (short)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResultViewModel<object>), (short)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] PessoaInputModel inputModel)
        {
            inputModel.Id = id;
            return Ok(await _pessoaService.AtualizarAsync(inputModel));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResultViewModel<bool>), (short)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResultViewModel<object>), (short)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
            => Ok(await _pessoaService.DeletarAsync(id));
    }
}
