using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoClientes.Dominio.Entidades
{
    [Table("Clientes")]
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public byte[] Imagem { get; set; }
        public string Tipo { get; set; }

    }
}
