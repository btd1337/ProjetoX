namespace BackRestApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("automacao.Alarme")]
    public partial class Alarme
    {
        public int Id { get; set; }

        public DateTime? DataAlarme { get; set; }

        [StringLength(45)]
        public string DescricaoAlarme { get; set; }

        public int IdEquipamento { get; set; }

        public virtual Equipamento Equipamento { get; set; }
    }
}
