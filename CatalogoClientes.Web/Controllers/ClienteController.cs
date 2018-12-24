using CatalogoClientes.Dominio.Entidades;
using CatalogoClientes.Dominio.Repositorio;
using PagedList;
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


        public ActionResult Catalogo(int? pagina)
        {
            int tamanhoPagina = 1;
            int numeroPagina = pagina ?? 1;
            return View(_repositorioCliente.GetTodos().ToPagedList(numeroPagina, tamanhoPagina));
        }


    }
}