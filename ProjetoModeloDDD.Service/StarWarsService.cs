using ProjetoModeloDDD.Domain.DTOs.Configurations;
using ProjetoModeloDDD.Domain.DTOs.ResponseModels;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Service
{
    public class StarWarsService : IStarWarsService
    {
        private readonly HttpClient _httpClient;
        private readonly StarWarsOptions _starWarsOptions;

        public StarWarsService(HttpClient httpClient, IOptions<StarWarsOptions> options)
        {
            _httpClient = httpClient;
            _starWarsOptions = options.Value;
        }

        public StarWarsOptions ObterConfiguracao()
            => _starWarsOptions;

        public async Task<StarWarsFilsResponse> ObterFilmesStarWarsAsync()
        {
            var retornoService = await _httpClient.GetAsync(_starWarsOptions.EndpointFilms);

            if (!retornoService.IsSuccessStatusCode)
                return new StarWarsFilsResponse();

            var jsonString = retornoService.Content.ReadAsStringAsync().Result;
            var meuObjeto = JsonConvert.DeserializeObject<StarWarsFilsResponse>(jsonString);

            return meuObjeto;
        }
    }
}
