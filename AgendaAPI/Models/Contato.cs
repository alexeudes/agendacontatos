using FluentValidation;

namespace AgendaAPI.Models
{
    public class Contato
    {
		public Contato() { }

		public int ID { get; set; }
		public string? Nome { get; set; }
		public string? Telefone { get; set; }
		public string? Email { get; set; }
	}
}

