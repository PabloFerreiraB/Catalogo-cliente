using CatalogoClientes.Dominio.Entidades;
using CatalogoClientes.Dominio.Repositorio;
using System.Web.Mvc;

namespace CatalogoClientes.Web.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        private IRepositorio<Cliente> _repositorioCliente;

        public ClienteController()
        {
            _repositorioCliente = new ClienteRepositorio(new ClienteContexto());
        }


        public ActionResult Catalogo()
        {
            return View(_repositorioCliente.GetTodos());
        }


    }
}