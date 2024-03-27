using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ClienteBusiness
    {
        ClientesDAL clientesDAL = new ClientesDAL();
        public void AltaCliente(ClientesEntity cliente)
        {
            foreach(ClientesEntity clientes in GetCliente())
            {
                if (clientes.Usuario == cliente.Usuario || clientes.Email == cliente.Email) throw new Exception("El usuario y/0 el email ya esta registrado");
            }
            if (cliente.Nombre=="" || cliente.Telefono.ToString() == "" || cliente.Usuario == "" || cliente.Contraseña == "" || cliente.Email == "") throw new Exception("Debe completar todos los campos!");
            clientesDAL.Alta(cliente);
        }
        public List<ClientesEntity> GetCliente()
        {
            return clientesDAL.Get();
        }

        public void EliminarCliente(ClientesEntity cliente)
        {
            clientesDAL.Eliminar(cliente);
        }
        public void ModificarCliente(ClientesEntity cliente)
        {
            clientesDAL.Modificar(cliente);
        }
    }
}
