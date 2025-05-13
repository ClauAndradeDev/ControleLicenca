using ControleLicenca.Entidades;
using ControleLicenca.Modelo.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ControleLicenca.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Licenca> Licencas { get; set; }
        public DbSet<Produto> Produtos { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Cliente
            modelBuilder.Entity<Cliente>()
                .ToTable("Cliente");

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Cliente>()
                .Property(c => c.DataCadastro);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Nome);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Telefone);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Email);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.CNPJ);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Situacao);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Contratos)
                .WithOne(cont => cont.Clientes)
                .HasForeignKey(cont => cont.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Contrato
            modelBuilder.Entity<Contrato>()
                .ToTable("Contrato");

            modelBuilder.Entity<Contrato>()
               .HasKey(cont => cont.Id);

            modelBuilder.Entity<Contrato>()
                .Property(cont => cont.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Contrato>()
                .Property(cont => cont.Descricao);

            modelBuilder.Entity<Contrato>()
                .Property(cont => cont.DataCadastro);

            modelBuilder.Entity<Contrato>()
                .Property(cont => cont.DataInicio);

            modelBuilder.Entity<Contrato>()
                .Property(cont => cont.DataFinal);

            modelBuilder.Entity<Contrato>()
                .Property(cont => cont.ValorMensal);

            modelBuilder.Entity<Contrato>()
                .HasMany(c => c.Licencas)
                .WithOne(l => l.Contratos)
                .HasForeignKey(l => l.IdContrato)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Licenca
            modelBuilder.Entity<Licenca>()
                .ToTable("Licenca");

            modelBuilder.Entity<Licenca>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Licenca>()
                .Property(l => l.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Licenca>()
                .Property(l => l.DataMovimentacao);

            modelBuilder.Entity<Licenca>()
                .Property(l=>l.Situacao);

            modelBuilder.Entity<Licenca>()
                .Property(l=>l.CodigoHash);

            #endregion

            #region Produto
            modelBuilder.Entity<Produto>()
                .ToTable("Produto");

            modelBuilder.Entity<Produto>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Produto>()
                .Property(p=>p.DescricaoSistema);

            modelBuilder.Entity<Produto>()
                .HasMany(p => p.Licencas)
                .WithOne(l => l.Produtos)
                .HasForeignKey(l => l.IdProduto)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Usuario
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuario");

            modelBuilder.Entity<Usuario>()
                .HasKey(u=>u.Id);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Nome);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Acesso);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Senha);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.DataCadastro);

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public string ObterStringConexao()
        {
            return "Data Source=CLAUANDRADE\\SQLEXPRESS;Initial Catalog=LicencaDB;User Id=sa;Password=@Itapoa2023;Integrated Security=True;";

        }

        internal Task FindAsync(long id)
        {
            throw new NotImplementedException();
        }

    }
}
