using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BarberoBusiness
    {
        BarberosDAL barberosDAL= new BarberosDAL();
        public void AltaBarbero(BarberosEntity barbero)
        {
            if (barbero.Nombre == "" || barbero.Telefono.ToString() == "") throw new Exception("Debe completar todos los campos");
            barberosDAL.Alta(barbero);
        }

        public List<BarberosEntity> GetBarbero()
        {
            return barberosDAL.Get();
        }

        public void EliminarBarbero(BarberosEntity barbero)
        {
            barberosDAL.Eliminar(barbero);
        }
        public void ModificarBarbero(BarberosEntity barbero)
        {
            barberosDAL.Modificar(barbero);
        }
    }
}
