using CatalogoClientes.Dominio.Entidades;
using CatalogoClientes.Dominio.Repositorio;
using PagedList;
using System.Data.Entity;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CatalogoClientes.Web.Controllers
{
    public class ClienteController : Controller
    {

        private ClienteContexto db = new ClienteContexto();
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

        // GET: Cliente
        //public ActionResult Catalogo()
        //{
        //    return View(db.Clientes.ToList());
        //}

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteId,Nome,Email,Endereco,Imagem,Tipo")] Cliente cliente, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var arquivoImagem = new Cliente
                    {
                        Tipo = upload.ContentType
                    };

                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        arquivoImagem.Imagem = reader.ReadBytes(upload.ContentLength);
                    }

                    cliente.Imagem = arquivoImagem.Imagem;
                    cliente.Tipo = arquivoImagem.Tipo;
                }


                db.Clientes.Add(cliente);
                db.SaveChanges();
                TempData["mensagem"] = string.Format("{0} : adicionada com sucesso", cliente.Nome);

                return RedirectToAction("Catalogo");
            }

            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteId,Nome,Email,Endereco,Imagem,Tipo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Catalogo");
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Catalogo");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
