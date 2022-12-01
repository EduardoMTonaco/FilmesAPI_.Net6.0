using FilmesAPI.Models;
using System.Text.Json.Serialization;

namespace FilmesAPI.Data.Dtos.GerenteDto
{
    public class GetGerenteDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public object Cinemas { get; set; }
    }
}
