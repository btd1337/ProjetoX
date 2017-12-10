using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackRestApi.Models
{
    public class Maquina
    {
        public Int32 Id { get; set; }
        public String Nome { get; set; }
        public Int32 PecasBoas { get; set; }
        public Int32 PecasRuins { get; set; }
        public Double Taxa { get; set; }
        public String TempoParada { get; set; }
        public String TempoProducao { get; set; }

        
    }
}