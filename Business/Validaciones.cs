using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Validaciones
    {
        public static bool EsAdmin(ClientesEntity cliente)
        {
            if (cliente.Tipo == "admin") return true;
            else return false;
        }
    }
}
