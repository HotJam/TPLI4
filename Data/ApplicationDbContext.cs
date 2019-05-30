using System;
using Assistente.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assistente.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FavoritoReceita> FavoritoReceita { get; set; }
        public virtual DbSet<Ingrediente> Ingrediente { get; set; }
        public virtual DbSet<InventarioIngrediente> InventarioIngrediente { get; set; }
        public virtual DbSet<Receita> Receita { get; set; }
        public virtual DbSet<ReceitaIngrediente> ReceitaIngrediente { get; set; }
        public virtual DbSet<Utilizador> Utilizador { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-TFQ3JM9;Database=AssistentePessoal;User Id=sa;Password=tpli4;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FavoritoReceita>(entity =>
            {
                entity.Property(e => e.FavoritoReceitaId)
                    .HasColumnName("FavoritoReceitaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FavoritosId).HasColumnName("FavoritosID");

                entity.Property(e => e.ReceitaId).HasColumnName("ReceitaID");

                entity.HasOne(d => d.Favoritos)
                    .WithMany(p => p.FavoritoReceita)
                    .HasForeignKey(d => d.FavoritosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FavoritoReceita_Utilizador");

                entity.HasOne(d => d.Receita)
                    .WithMany(p => p.FavoritoReceita)
                    .HasForeignKey(d => d.ReceitaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FavoritoReceita_Receita");
            });

            modelBuilder.Entity<Ingrediente>(entity =>
            {
                entity.Property(e => e.IngredienteId).HasColumnName("IngredienteID");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InventarioIngrediente>(entity =>
            {
                entity.Property(e => e.InventarioIngredienteId)
                    .HasColumnName("InventarioIngredienteID")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.IngredienteId).HasColumnName("IngredienteID");

                entity.Property(e => e.InventarioId)
                    .HasColumnName("InventarioID")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Ingrediente)
                    .WithMany(p => p.InventarioIngrediente)
                    .HasForeignKey(d => d.IngredienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventarioIngrediente_Ingrediente1");

                entity.HasOne(d => d.Inventario)
                    .WithMany(p => p.InventarioIngrediente)
                    .HasForeignKey(d => d.InventarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventarioIngrediente_Utilizador");
            });

            modelBuilder.Entity<Receita>(entity =>
            {
                entity.Property(e => e.ReceitaId).HasColumnName("ReceitaID");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Nutricao)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Prodecimento)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReceitaIngrediente>(entity =>
            {
                entity.Property(e => e.ReceitaIngredienteId).HasColumnName("ReceitaIngredienteID");

                entity.Property(e => e.IngredienteId).HasColumnName("IngredienteID");

                entity.Property(e => e.ReceitaId).HasColumnName("ReceitaID");

                entity.HasOne(d => d.Ingrediente)
                    .WithMany(p => p.ReceitaIngrediente)
                    .HasForeignKey(d => d.IngredienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceitaIngrediente_Ingrediente");

                entity.HasOne(d => d.Receita)
                    .WithMany(p => p.ReceitaIngrediente)
                    .HasForeignKey(d => d.ReceitaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceitaIngrediente_Receita");
            });

            modelBuilder.Entity<Utilizador>(entity =>
            {
                entity.Property(e => e.UtilizadorId).HasColumnName("UtilizadorID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.FavoritosId).HasColumnName("FavoritosID");

                entity.Property(e => e.InventarioId).HasColumnName("InventarioID");

                entity.Property(e => e.ListaComprasId).HasColumnName("ListaComprasID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });
        }
    }
}
