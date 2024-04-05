using Microsoft.EntityFrameworkCore;
using MinimalApiCatalogo.Models;
using System.Security.Cryptography.X509Certificates;

namespace MinimalApiCatalogo.Context
{
    //Classe DbContext servce como uma ponte
    //entre nossas entidades e o banco de dados sql
    public class AppDbContext : DbContext        
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        
        public DbSet<Ingresso>? Ingresso { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //categoria
            mb.Entity<Categoria>().HasKey(c => c.CategoriaId);

            mb.Entity<Categoria>().Property(c => c.Nome)
                                  .HasMaxLength(100)
                                  .IsRequired();
            mb.Entity<Categoria>().Property(c => c.Descricao)
                                  .HasMaxLength(150)
                                  .IsRequired();

            //Produto/Ingresso
            mb.Entity<Ingresso>().HasKey(c => c.IngressoId);
            mb.Entity<Ingresso>().Property(c => c.Nome)
                                  .HasMaxLength(100)
                                  .IsRequired();
            mb.Entity<Ingresso>().Property(c => c.Descricao)
                                  .HasMaxLength(150);
            mb.Entity<Ingresso>().Property(c => c.Imagem)
                                  .HasMaxLength(100);
            mb.Entity<Ingresso>().Property(c => c.Preco)
                                  .HasPrecision(14, 2);

            //relacionamento
            mb.Entity<Ingresso>()
                .HasOne<Categoria>(c => c.Categoria)
                  .WithMany(i => i.Ingressos)
                    .HasForeignKey(c => c.CategoriaId);              

        }
    }
}
