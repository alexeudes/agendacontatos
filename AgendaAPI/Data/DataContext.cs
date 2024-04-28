using AgendaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPI.Data
{
    public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var contact = builder.Entity<Contato>();
            contact.ToTable("contato");
            contact.HasKey(attribute => attribute.ID);
            contact.Property(attribute => attribute.ID).HasColumnName("id").ValueGeneratedOnAdd();
            contact.Property(attribute => attribute.Nome).HasColumnName("nome").IsRequired();
            contact.Property(attribute => attribute.Telefone).HasColumnName("telefone").IsRequired();
            contact.Property(attribute => attribute.Email).HasColumnName("email").IsRequired();

            base.OnModelCreating(builder);
        }
    }
}

