using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ServicioDAL
    {
        public List<ServicioEntity> Get()
        {
            using (Context context= new Context())
            {
                return context.Servicio.ToList().Select(s => new ServicioEntity
                {
                    Id=Convert.ToInt32(s.ID),
                    Servicio=s.SERVICIO1,
                    Precio=s.PRECIO
                }).ToList();
            }
        }
    }
}
