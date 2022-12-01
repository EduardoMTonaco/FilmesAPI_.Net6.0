using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Resquest
{
    public class SolicitaResetRequest : IResetRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
