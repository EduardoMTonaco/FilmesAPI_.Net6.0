using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Titulo é obrigatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Campo Diretor é obrigatorio")]
        public string Diretor { get; set; }
        [StringLength(50, ErrorMessage = "O Gênero não pode ter mais de 50 caracteres")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "Campo Duração é obrigatorio")]
        [Range(1, 600, ErrorMessage = "A duração do filme deve ter no mínimo 1 minuto e no máximo 600 minutos")]
        public int Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }
        [JsonIgnore]
        public List<Sessao> Sessoes { get; set; }

    }
}
