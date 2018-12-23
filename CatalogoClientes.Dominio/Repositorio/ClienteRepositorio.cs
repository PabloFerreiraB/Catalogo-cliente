using CatalogoClientes.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoClientes.Dominio.Repositorio
{
    public class ClienteRepositorio : IRepositorio<Cliente>
    {
        private ClienteContexto contexto;

        public ClienteRepositorio(ClienteContexto clienteContexto)
        {
            this.contexto = clienteContexto;
        }

        public IEnumerable<Cliente> GetTodos()
        {
            return contexto.Clientes.ToList();
        }
    }
}
