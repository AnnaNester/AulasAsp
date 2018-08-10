using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceOsorio.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage ="Campo obrigatório!")] [MaxLength(50, ErrorMessage = "O campo deve ter no máximo 50 caracteres!")]
        [Display(Name ="Nome do produto")]
        public string NomeProduto { get; set; }

        [Display(Name = "Descrição do produto")]
        [DataType(DataType.MultilineText)]
        public string DescricaoProduto { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Preço do produto")]
        public double PrecoProduto { get; set; }

        [Display(Name = "Categoria do produto")]
        public Categoria CategoriaProduto { get; set; }

        [Display(Name = "Imagem do produto")]
        public string ImagemProduto { get; set; }
    }
}