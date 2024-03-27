using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ClientesEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public long Telefono { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }
    }
}
