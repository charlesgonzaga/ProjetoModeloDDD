using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.DTOs.ResponseModels
{
    public class StarWarsFilsResponse
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<FilmsResponse> results { get; set; }
    }
}
