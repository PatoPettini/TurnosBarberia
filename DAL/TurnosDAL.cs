using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TurnosDAL
    {
        public void Alta(TurnosEntity turno)
        {
            ReservaTurno tur = new ReservaTurno();
            if (turno.IdCliente == 0)
            {
                tur.CLIENTES= new CLIENTES();
                tur.CLIENTES.NOMBRE = turno.Cliente.Nombre;
                tur.CLIENTES.Tipo = "cliente";
            }
            else tur.ID_CLIENTE = turno.IdCliente;
            tur.ID_PELUQUERO = turno.IdPeluquero;
            tur.ID_SERVICIO = turno.IdServicio;
            tur.Dia = turno.Dia;
            tur.Hora = turno.Hora;
            using (Context context = new Context())
            {
                context.ReservaTurno.Add(tur);
                context.SaveChanges();
            }
        }
        public void Eliminar(TurnosEntity turno)
        {
            using (Context context = new Context())
            {
                ReservaTurno tur = context.ReservaTurno.FirstOrDefault(t => t.ID == turno.Id);
                context.ReservaTurno.Remove(tur);
                context.SaveChanges();
            }
        }
        public void Modificar(TurnosEntity turno)
        {
            using (Context context = new Context())
            {
                ReservaTurno tur = context.ReservaTurno.FirstOrDefault(t => t.ID == turno.Id);
                if (turno.IdCliente != 0) tur.ID_CLIENTE = turno.IdCliente;
                else
                {
                    tur.CLIENTES = new CLIENTES();
                    tur.CLIENTES.NOMBRE = turno.Cliente.Nombre; 
                    tur.CLIENTES.Tipo = "cliente";
                }
                tur.ID_PELUQUERO = turno.IdPeluquero;
                tur.ID_SERVICIO = turno.IdServicio;
                tur.Dia = turno.Dia;
                tur.Hora = turno.Hora;
                context.SaveChanges();
            }
        }
        public List<TurnosEntity> Get()
        {
            using (Context context = new Context())
            {
                List<TurnosEntity> lista= context.ReservaTurno.ToList().OrderBy(t=>t.Hora).Select(tur => new TurnosEntity()
                {
                    Id = Convert.ToInt32(tur.ID),
                    IdCliente = Convert.ToInt32(tur.ID_CLIENTE),
                    IdPeluquero = Convert.ToInt32(tur.ID_PELUQUERO),
                    IdServicio = Convert.ToInt32(tur.ID_SERVICIO),
                    Dia = tur.Dia,
                    Hora = tur.Hora,
                }).OrderBy(t=>t.Dia).ToList();

                foreach(TurnosEntity tur in lista)
                {
                    CLIENTES cli=context.CLIENTES.FirstOrDefault(c => c.ID == tur.IdCliente);
                    tur.Cliente = new ClientesEntity();
                    tur.Cliente.Nombre = cli.NOMBRE;
                    tur.Cliente.Usuario = cli.USUARIO;
                }
                foreach (TurnosEntity tur in lista)
                {
                    BARBEROS bar = context.BARBEROS.FirstOrDefault(b => b.ID == tur.IdPeluquero);
                    tur.Barbero = new BarberosEntity();
                    tur.Barbero.Nombre = bar.NOMBRE;
                }
                foreach (TurnosEntity tur in lista)
                {
                    Servicio ser = context.Servicio.FirstOrDefault(s => s.ID == tur.IdServicio);
                    tur.Servicio = new ServicioEntity();
                    tur.Servicio.Servicio = ser.SERVICIO1;
                    tur.Servicio.Precio = ser.PRECIO;
                }
                return lista;
            }
        }
    }
}
