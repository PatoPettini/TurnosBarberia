using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClientesDAL
    {
        public void Alta(ClientesEntity cliente)
        {
            CLIENTES cli = new CLIENTES();
            cli.NOMBRE = cliente.Nombre;
            cli.TELEFONO = cliente.Telefono;
            cli.USUARIO = cliente.Usuario;
            cli.CONTRASEÑA = cliente.Contraseña;
            cli.Email= cliente.Email;
            cli.Tipo=cliente.Tipo;
            using (Context context = new Context())
            {
                context.CLIENTES.Add(cli);
                context.SaveChanges();
            }
        }
        public void Eliminar(ClientesEntity cliente)
        {
            using (Context context = new Context())
            {
                CLIENTES cli = context.CLIENTES.FirstOrDefault(c => c.ID == cliente.Id);
                context.CLIENTES.Remove(cli);
                context.SaveChanges();
            }
        }
        public void Modificar(ClientesEntity cliente)
        {
            using (Context context = new Context())
            {
                CLIENTES cli = context.CLIENTES.FirstOrDefault(c => c.ID == cliente.Id);
                cli.NOMBRE = cliente.Nombre;
                cli.TELEFONO = cliente.Telefono; 
                cli.USUARIO = cliente.Usuario;
                cli.CONTRASEÑA = cliente.Contraseña;
                cli.Email = cliente.Email;
                cli.Tipo = cliente.Tipo;
                context.SaveChanges();
            }
        }
        public List<ClientesEntity> Get()
        {
            using (Context context = new Context())
            {
                return context.CLIENTES.ToList().Select(cli => new ClientesEntity()
                {
                    Id = Convert.ToInt32(cli.ID),
                    Nombre = cli.NOMBRE,
                    Telefono = Convert.ToInt32(cli.TELEFONO),
                    Usuario=cli.USUARIO,
                    Contraseña=cli.CONTRASEÑA,
                    Email=cli.Email,
                    Tipo=cli.Tipo
                }).ToList();
            }
        }
    }
}
