using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Odonto.Core.Models;

namespace Odonto.Data.EntityFramework
{
    public class Contexto : IdentityDbContext<ApplicationUser>
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
        }

        public static Contexto Create(DbContextOptions<Contexto> options)
        {
            return new Contexto(options);
        }

        public DbSet<Licao> Licoes { get; set; }
        public DbSet<Topico> Topicos { get; set; }
        public DbSet<Assunto> Assuntos { get; set; }
        public DbSet<Questao> Questoes { get; set; }
        //public DbSet<Alternativa> Alternativas { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<MobileUser> MobileUsers { get; set; }
        /*public DbSet<LicaoQuestao> LicaoQuestoes { get; set; }
        public DbSet<ExercicioQuestao> ExercicioQuestoes { get; set; }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Licao>().HasKey(c => c.Id);

            modelBuilder.Entity<Topico>()
                .HasMany(t => t.Licoes);
            modelBuilder.Entity<Licao>()
                .HasOne(t => t.Topico)
                .WithMany(t => t.Licoes)
                .IsRequired()
                .HasForeignKey(t => t.TopicoId)
                .OnDelete(DeleteBehavior.Restrict);
            /*modelBuilder.Entity<Licao>()
                .HasMany(t => t.Questoes)
                .WithOne(t => t.Licao)
                .HasForeignKey(t => t.LicaoId)
                .OnDelete(DeleteBehavior.Restrict);*/

            modelBuilder.Entity<Topico>().HasKey(t => t.Id);

            modelBuilder.Entity<Assunto>()
                .HasMany(t => t.Subtopicos);
            modelBuilder.Entity<Topico>()
                .HasOne(t => t.Assunto)
                .WithMany(t => t.Subtopicos)
                .IsRequired()
                .HasForeignKey(t => t.AssuntoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Assunto>().HasKey(t => t.Id);

            modelBuilder.Entity<Topico>()
                .HasMany(t => t.Subtopicos);
            modelBuilder.Entity<Topico>()
                .HasOne(t => t.TopicoPai)
                .WithMany(t => t.Subtopicos)
                .IsRequired()
                .HasForeignKey(t => t.TopicoPaiId)
                .OnDelete(DeleteBehavior.Restrict);

            /*modelBuilder.Entity<ExercicioQuestao>()
                .HasKey(pc => new { pc.QuestaoId, pc.ExercicioId });

            modelBuilder.Entity<ExercicioQuestao>()
                .HasOne(e => e.Exercicio)
                .WithMany(e => e.Questoes)
                .HasForeignKey(e => e.QuestaoId);

            modelBuilder.Entity<ExercicioQuestao>()
                .HasOne(pc => pc.Questao)
                .WithMany(c => c.Exercicios)
                .HasForeignKey(pc => pc.ExercicioId);

            modelBuilder.Entity<LicaoQuestao>()
                .HasKey(pc => new { pc.QuestaoId, pc.LicaoId });

            modelBuilder.Entity<LicaoQuestao>()
                .HasOne(e => e.Licao)
                .WithMany(e => e.Questoes)
                .HasForeignKey(e => e.QuestaoId);

            modelBuilder.Entity<LicaoQuestao>()
                .HasOne(pc => pc.Questao)
                .WithMany(c => c.Licoes)
                .HasForeignKey(pc => pc.LicaoId);*/

            modelBuilder.Entity<Questao>().HasKey(t => t.Id);

            modelBuilder.Entity<Exercicio>()
                .HasMany(t => t.Questoes)
                .WithOne(t => t.Exercicio)
                .IsRequired()
                .HasForeignKey(t => t.ExercicioId)
                .OnDelete(DeleteBehavior.Cascade);

            /*modelBuilder.Entity<Alternativa>().HasKey(t => t.Id);

            modelBuilder.Entity<Questao>()
                .HasMany(t => t.Alternativas)
                .WithOne(t => t.Questao)
                .HasForeignKey(t => t.QuestaoId)
                .OnDelete(DeleteBehavior.Cascade);*/

            modelBuilder.Entity<MobileUser>().HasKey(t => t.Id);
            modelBuilder.Entity<MobileUser>().Property(t => t.Login).IsRequired();
            modelBuilder.Entity<MobileUser>().Property(t => t.Password).IsRequired();
            modelBuilder.Entity<MobileUser>().HasIndex(t => t.Login).IsUnique();
        }
    }
}
