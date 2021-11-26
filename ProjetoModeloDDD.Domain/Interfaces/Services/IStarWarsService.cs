using ProjetoModeloDDD.Domain.DTOs.Configurations;
using ProjetoModeloDDD.Domain.DTOs.ResponseModels;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IStarWarsService
    {
        StarWarsOptions ObterConfiguracao();
        Task<StarWarsFilsResponse> ObterFilmesStarWarsAsync();
    }
}
