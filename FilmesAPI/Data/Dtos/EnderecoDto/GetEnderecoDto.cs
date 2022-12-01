using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Data.Dtos.EnderecoDto
{
    public class GetEnderecoDto
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }

    }
}
