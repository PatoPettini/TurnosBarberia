using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class TurnosEntity
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public ClientesEntity Cliente { get; set; }
        public int IdPeluquero { get; set; }
        public BarberosEntity Barbero { get; set; }
        public int IdServicio { get; set; }
        public ServicioEntity Servicio { get; set; }
        public DateTime Dia { get; set; }
        public TimeSpan Hora { get; set; }

    }
}
