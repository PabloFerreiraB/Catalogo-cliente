using CatalogoClientes.Dominio.Entidades;
using System.Web.Mvc;

namespace CatalogoClientes.Web.Controllers
{
    public class ArquivoController : Controller
    {
        // GET: Arquivo
        public ActionResult ExibirImagem(int id)
        {
            using (ClienteContexto db = new ClienteContexto())
            {
                var arquivoRetorno = db.Clientes.Find(id);
                return File(arquivoRetorno.Imagem, arquivoRetorno.Tipo);
            }
        }
    }
}