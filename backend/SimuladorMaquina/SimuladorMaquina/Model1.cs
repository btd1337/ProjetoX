namespace SimuladorMaquina
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Alarme> Alarme { get; set; }
        public virtual DbSet<Equipamento> Equipamento { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alarme>()
                .Property(e => e.DescricaoAlarme)
                .IsUnicode(false);

            modelBuilder.Entity<Equipamento>()
                .Property(e => e.NomeEquipamento)
                .IsUnicode(false);

            modelBuilder.Entity<Equipamento>()
                .HasMany(e => e.Alarme)
                .WithRequired(e => e.Equipamento)
                .HasForeignKey(e => e.IdEquipamento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipamento>()
                .HasMany(e => e.Evento)
                .WithRequired(e => e.Equipamento)
                .HasForeignKey(e => e.IdEquipamento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Evento>()
                .Property(e => e.DataEvento)
                .IsUnicode(false);

            modelBuilder.Entity<Evento>()
                .Property(e => e.TempoProducao)
                .IsUnicode(false);

            modelBuilder.Entity<Evento>()
                .Property(e => e.TempoParada)
                .IsUnicode(false);
        }
    }
}
