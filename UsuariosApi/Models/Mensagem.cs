using MimeKit;

namespace UsuariosApi.Models
{
    public class Mensagem
    {
        public List<MailboxAddress> Destinatario;
        public string Assunto;
        public string Conteudo;

        public Mensagem(IEnumerable<string> destinatario, string assunto, int usuarioId, string codigo)
        {

            this.Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(d => new MailboxAddress(d.Remove(d.IndexOf('@')), d)));
            this.Assunto = assunto;
            this.Conteudo = $"https://localhost:7065/ativa?usuarioId={usuarioId}&codigodeativacao={codigo}";
        }
    }
}
