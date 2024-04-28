namespace AgendaAPI.DTOs
{
    public class ContatoDTO
	{
		public ContatoDTO() { }

        public int ID { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
    }
}

