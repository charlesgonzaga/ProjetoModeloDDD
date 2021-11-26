using ProjetoModeloDDD.Domain.DTOs.Configurations;
using ProjetoModeloDDD.Domain.DTOs.ResponseModels;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Api.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    [ApiController]
    public class StarWarsExternoController : ControllerBase
    {
        private readonly IStarWarsService _starWarsService;

        public StarWarsExternoController(IStarWarsService starWarsService)
        {
            _starWarsService = starWarsService;
        }

        [HttpGet("ObterFilmesStarWars")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<StarWarsFilsResponse> ObterFilmesStarWars()
            => await _starWarsService.ObterFilmesStarWarsAsync();

        [HttpGet("ObterConfiguracaoStarWars")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public StarWarsOptions ObterConfiguracaoStarWars()
            => _starWarsService.ObterConfiguracao();
    }
}
