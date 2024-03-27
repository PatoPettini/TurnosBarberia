namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReservaTurno")]
    public partial class ReservaTurno
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ID_CLIENTE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ID_PELUQUERO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ID_SERVICIO { get; set; }

        [Column(TypeName = "date")]
        public DateTime Dia { get; set; }

        public TimeSpan Hora { get; set; }

        public virtual BARBEROS BARBEROS { get; set; }

        public virtual CLIENTES CLIENTES { get; set; }

        public virtual Servicio Servicio { get; set; }
    }
}
