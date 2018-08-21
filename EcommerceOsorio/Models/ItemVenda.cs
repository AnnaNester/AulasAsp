using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceOsorio.Models
{
    [Table("ItemVenda")]
    public class ItemVenda
    {
        [Key]
        public int idVenda { get; set; }

        public Produto ProdutoVenda { get; set; }

        public int QtdeVenda { get; set; }

        public double PrecoVenda { get; set; }

        public DateTime DataVenda { get; set; }

        public string CarrinhoId { get; set; }
    }
}