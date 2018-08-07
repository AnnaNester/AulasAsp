using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceOsorio.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Campor obrigatório!")]
        [Display(Name ="Nome da categoria")]
        public string NomeCategoria { get; set; }

        [Required]
        [Display(Name = "Descrição da categoria")]
        public string DescricaoCategoria { get; set; }
    }
}