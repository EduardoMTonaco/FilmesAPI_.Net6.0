using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos.CinemaDto
{
    public class GetCinemaDto
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public int GerenteId { get; set; }
        public Gerente Gerente { get; set; }
        public List<Sessao> Sessao { get; set;}
    }
}
