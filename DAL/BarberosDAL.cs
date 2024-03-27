using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BarberosDAL
    {
        public void Alta(BarberosEntity barbero)
        {
            BARBEROS bar= new BARBEROS();
            bar.NOMBRE = barbero.Nombre;
            bar.TELEFONO = barbero.Telefono;
            using (Context context= new Context())
            {
                context.BARBEROS.Add(bar);
                context.SaveChanges();
            }
        }
        public void Eliminar(BarberosEntity barbero)
        {
            using (Context context= new Context())
            {
                BARBEROS bar = context.BARBEROS.FirstOrDefault(b => b.ID == barbero.Id);
                context.BARBEROS.Remove(bar);
                context.SaveChanges();
            }
        }
        public void Modificar(BarberosEntity barbero)
        {
            using (Context context = new Context())
            {
                BARBEROS bar = context.BARBEROS.FirstOrDefault(b => b.ID == barbero.Id);
                bar.NOMBRE = barbero.Nombre;
                bar.TELEFONO = barbero.Telefono;
                context.SaveChanges();
            }
        }
        public List<BarberosEntity> Get()
        {
            using (Context context= new Context())
            {
                return context.BARBEROS.ToList().Select(bar => new BarberosEntity()
                {
                    Id=Convert.ToInt32(bar.ID),
                    Nombre=bar.NOMBRE,
                    Telefono= Convert.ToInt32(bar.TELEFONO)
                }).ToList();
            }
        }
    }
}
