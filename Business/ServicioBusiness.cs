using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ServicioBusiness
    {
        ServicioDAL servicioDAL= new ServicioDAL();
        public List<ServicioEntity> GetServicios()
        {
            return servicioDAL.Get();
        }
    }
}
