using System.Data.Entity;

namespace CatalogoClientes.Dominio.Entidades
{
    public class ClienteContexto : DbContext
    {
        public ClienteContexto() : base("name=ConexaoClientes")
        {

        }

        //Se o banco de dados não existir, então cria o banco de dados
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ClienteContexto>(new CreateDatabaseIfNotExists<ClienteContexto>());
        }


        //Mapeando a tabela Clientes
        public DbSet<Cliente> Clientes { get; set; }


    }
}
