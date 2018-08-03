using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceOsorio.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        public string NomeProduto { get; set; }

        public string DescricaoProduto { get; set; }

        public double PrecoProduto { get; set; }

        public string CategoriaProduto { get; set; }

        public string ImagemProduto { get; set; }
    }
}