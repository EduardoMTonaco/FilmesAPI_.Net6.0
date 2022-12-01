using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FilmesAPI.Data.Dtos.EnderecoDto;
using FilmesAPI.Data.Dtos.GerenteDto;
using FilmesAPI.Data.Dtos.SessaoDto;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos.CinemaDto
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public GetEnderecoDto Endereco { get; set; }
        public int GerenteId { get; set; }
        public GetGerenteDto Gerente { get; set; }
        public List<GetSessaoDto> Sessao { get; set;}
    }
}
