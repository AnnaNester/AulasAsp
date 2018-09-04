using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceOsorio.Models
{
    [Table("Vendas")]
    public class Venda
    {
        [Key]
        public int VendaId { get; set; }

        [Display(Name = "Nome do cliente")]
        public string Nome { get; set; }

        [Display(Name = "Telefone do cliente")]
        public string Telefone { get; set; }

        [Display(Name = "Endereço do cliente")]
        public string Endereco { get; set; }
        public string CarrinhoId { get; set; }
        public List<ItemVenda> ItensVenda { get; set; }

    }

}