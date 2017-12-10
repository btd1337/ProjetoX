namespace SimuladorMaquina
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("automacao.Evento")]
    public partial class Evento
    {
        public int Id { get; set; }

        [StringLength(45)]
        public string DataEvento { get; set; }

        public int? PecasBoas { get; set; }

        public int? PecasRuins { get; set; }

        [StringLength(45)]
        public string TempoProducao { get; set; }

        [StringLength(45)]
        public string TempoParada { get; set; }

        public int IdEquipamento { get; set; }

        public virtual Equipamento Equipamento { get; set; }
    }
}
