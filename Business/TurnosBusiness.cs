using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TurnosBusiness
    {
        TurnosDAL turnosDAL = new TurnosDAL();
        public void AltaTurno(TurnosEntity turno)
        {
            int dia = Convert.ToInt32(turno.Dia.DayOfWeek);
            if (Convert.ToDateTime(turno.Dia) == DateTime.Today && turno.Hora > TimeSpan.Parse(DateTime.Now.ToString("t"))) throw new Exception("El turno no puede ser para una hora anterior a la actual");
            else if (turno.Dia < DateTime.Today) throw new Exception("El dia no puede ser anterior al dia de hoy");
            else if (Convert.ToDateTime(turno.Dia) > DateTime.Now.AddDays(7)) throw new Exception("No se puede reservar un turno para mas de una semana");
            else if (dia == 0) throw new Exception("Los domingos no está abierta la barberia");
            foreach (TurnosEntity tur in GetTurno())
            {
                if (turno.Dia == tur.Dia && tur.Hora == turno.Hora) throw new Exception("La hora seleccionada ya fue reservada");
            }
            turnosDAL.Alta(turno);
        }
        public List<TurnosEntity> GetTurno()
        {
            return turnosDAL.Get();
        }

        public void ValidarId(TurnosEntity turno, ClientesEntity cliente)
        {
            if (cliente.Tipo != "admin")
            {
                if (turno.IdCliente != cliente.Id) throw new Exception("No tiene permiso para ingresar a este sitio");
            }
        }

        public List<TimeSpan> GetTurnosDisponibles(string dia, string barbero)
        {
            int diadelasemana = Convert.ToInt32(Convert.ToDateTime(dia).DayOfWeek);
            List<TimeSpan> lista = new List<TimeSpan>();
            lista.Add(TimeSpan.Parse("10:00"));
            lista.Add(TimeSpan.Parse("10:40"));
            lista.Add(TimeSpan.Parse("11:20"));
            lista.Add(TimeSpan.Parse("12:00"));
            lista.Add(TimeSpan.Parse("12:40"));
            lista.Add(TimeSpan.Parse("13:20"));
            lista.Add(TimeSpan.Parse("14:00"));
            lista.Add(TimeSpan.Parse("14:40"));
            lista.Add(TimeSpan.Parse("15:20"));
            lista.Add(TimeSpan.Parse("16:00"));
            lista.Add(TimeSpan.Parse("16:40"));
            lista.Add(TimeSpan.Parse("17:20"));
            lista.Add(TimeSpan.Parse("18:00"));
            lista.Add(TimeSpan.Parse("18:40"));
            lista.Add(TimeSpan.Parse("19:20"));
            lista.Add(TimeSpan.Parse("20:00"));
            List<TimeSpan> nl = new List<TimeSpan>();

            if (Convert.ToDateTime(dia) == DateTime.Today)
            {
                foreach (TimeSpan hora in lista)
                {
                    if (hora < TimeSpan.Parse(DateTime.Now.ToString("t")))
                    {
                        nl.Add(hora);
                    }
                }
                if (nl.Count > 0)
                {
                    for (int i = 0; i < nl.Count; i++)
                    {
                        lista.Remove(nl[i]);
                    }
                }
            }

            if (diadelasemana == 6)
            {
                lista.Remove(TimeSpan.Parse("20:00"));
            }
            List<TimeSpan> listaNueva = new List<TimeSpan>();
            foreach (TurnosEntity turno in GetTurno())
            {
                if (turno.Dia == Convert.ToDateTime(dia))
                {
                    if (turno.Barbero.Nombre == barbero)
                    {
                        foreach (TimeSpan hora in lista)
                        {
                            if (turno.Hora == hora) listaNueva.Add(hora);
                        }
                    }
                }
            }
            if (listaNueva.Count > 0)
            {
                for (int i = 0; i < listaNueva.Count; i++)
                {
                    lista.Remove(listaNueva[i]);
               }
            }
            return lista;
        }

        public void EliminarTurno(TurnosEntity turno)
        {
            turnosDAL.Eliminar(turno);
        }
        public void ModificarTurno(TurnosEntity turno)
        {
            turnosDAL.Modificar(turno);
        }
        public List<TurnosEntity> FiltrarTurnos(string barbero, string servicio, string estado, string mes, string dia)
        {
            List<TurnosEntity> lista = new List<TurnosEntity>();
            if (barbero == "Cualquiera" && servicio == "Cualquiera")
            {
                lista = GetTurno();
                List<TurnosEntity> listaNueva = FiltrarPorEstado(lista, estado);
                List<TurnosEntity> lista2 = FiltrarPorMes(listaNueva, mes);
                return FiltrarPorDia(lista2, dia);
            }
            else if (barbero != "Cualquiera" && servicio == "Cualquiera")
            {
                foreach (TurnosEntity turno in GetTurno())
                {
                    if (turno.Barbero.Nombre == barbero) lista.Add(turno);
                }
                List<TurnosEntity> listaNueva = FiltrarPorEstado(lista, estado);
                List<TurnosEntity> lista2 = FiltrarPorMes(listaNueva, mes);
                return FiltrarPorDia(lista2, dia);
            }
            else if (barbero == "Cualquiera" && servicio != "Cualquiera")
            {
                foreach (TurnosEntity turno in GetTurno())
                {
                    if (turno.Servicio.Servicio == servicio) lista.Add(turno);
                }
                List<TurnosEntity> listaNueva = FiltrarPorEstado(lista, estado);
                List<TurnosEntity> lista2 = FiltrarPorMes(listaNueva, mes);
                return FiltrarPorDia(lista2, dia);
            }
            else if (barbero != "Cualquiera" && servicio != "Cualquiera")
            {
                foreach (TurnosEntity turno in GetTurno())
                {
                    if (turno.Servicio.Servicio == servicio && turno.Barbero.Nombre == barbero) lista.Add(turno);
                }
                List<TurnosEntity> listaNueva = FiltrarPorEstado(lista, estado);
                List<TurnosEntity> lista2 = FiltrarPorMes(listaNueva, mes);
                return FiltrarPorDia(lista2, dia);
            }
            return null;
        }

        public List<TurnosEntity> FiltrarPorDia(List<TurnosEntity> lista, string dia)
        {
            List<TurnosEntity> listaFiltrada = new List<TurnosEntity>();
            if (!string.IsNullOrEmpty(dia))
            {
                foreach (TurnosEntity turno in lista)
                {
                    if (turno.Dia == Convert.ToDateTime(dia)) listaFiltrada.Add(turno);
                }
                return listaFiltrada;
            }
            return lista;
        }

        public List<TurnosEntity> FiltrarPorEstado(List<TurnosEntity> lista, string estado)
        {
            List<TurnosEntity> listaFiltrada = new List<TurnosEntity>();
            if (estado == "Cualquiera")
            {
                return lista;
            }
            else if (estado == "Atendido")
            {
                foreach (TurnosEntity turno in lista)
                {
                    if (turno.Dia < DateTime.Today) listaFiltrada.Add(turno);
                    if (turno.Dia == DateTime.Today && turno.Hora < DateTime.Now.TimeOfDay) listaFiltrada.Add(turno);
                }
            }
            else
            {
                foreach (TurnosEntity turno in lista)
                {
                    if (turno.Dia > DateTime.Today) listaFiltrada.Add(turno);
                    if (turno.Dia == DateTime.Today && turno.Hora > DateTime.Now.TimeOfDay) listaFiltrada.Add(turno);
                }
            }
            return listaFiltrada;
        }

        public List<TurnosEntity> FiltrarPorMes(List<TurnosEntity> lista, string mes)
        {
            List<TurnosEntity> nuevaLista = new List<TurnosEntity>();
            if (mes == "Cualquiera" || mes=="") return lista;
            if (mes == "Enero")
            {
                foreach (TurnosEntity turnos in lista)
                {
                    if (turnos.Dia.Month == 1) nuevaLista.Add(turnos);
                }
            }
            else if (mes == "Febrero")
            {
                foreach (TurnosEntity turnos in lista)
                {
                    if (turnos.Dia.Month == 2) nuevaLista.Add(turnos);
                }
            }
            else if (mes == "Marzo")
            {
                foreach (TurnosEntity turnos in lista)
                {
                    if (turnos.Dia.Month == 3) nuevaLista.Add(turnos);
                }
            }
            else if (mes == "Abril")
            {
                foreach (TurnosEntity turnos in lista)
                {
                    if (turnos.Dia.Month == 4) nuevaLista.Add(turnos);
                }
            }
            else if (mes == "Mayo")
            {
                foreach (TurnosEntity turnos in lista)
                {
                    if (turnos.Dia.Month == 5) nuevaLista.Add(turnos);
                }
            }
            else if (mes == "Junio")
            {
                foreach (TurnosEntity turnos in lista)
                {
                    if (turnos.Dia.Month == 6) nuevaLista.Add(turnos);
                }
            }
            else if (mes == "Julio")
            {
                foreach (TurnosEntity turnos in lista)
                {
                    if (turnos.Dia.Month == 7) nuevaLista.Add(turnos);
                }
            }
            else if (mes == "Agosto")
            {
                foreach (TurnosEntity turnos in lista)
                {
                    if (turnos.Dia.Month == 8) nuevaLista.Add(turnos);
                }
            }
            else if (mes == "Septiembre")
            {
                foreach (TurnosEntity turnos in lista)
                {
                    if (turnos.Dia.Month == 9) nuevaLista.Add(turnos);
                }
            }
            else if (mes == "Octubre")
            {
                foreach (TurnosEntity turnos in lista)
                {
                    if (turnos.Dia.Month == 10) nuevaLista.Add(turnos);
                }
            }
            else if (mes == "Noviembre")
            {
                foreach (TurnosEntity turnos in lista)
                {
                    if (turnos.Dia.Month == 11) nuevaLista.Add(turnos);
                }
            }
            else if (mes == "Diciembre")
            {
                foreach (TurnosEntity turnos in lista)
                {
                    if (turnos.Dia.Month == 12) nuevaLista.Add(turnos);
                }
            }
            return nuevaLista;
        }

    }
}
