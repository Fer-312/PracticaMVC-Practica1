using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace PracticaMVC.Models
{
    public class marcas
    {
        [Key]
        [DisplayName ("Id de la marca")]
        public int id_marcas { get; set; }
        [DisplayName("Nombre de la Marca")]
        [Required(ErrorMessage = "El nombre de la marca NO es opcional!")]
        public string? nombre_marca { get; set; }
        [Display(Name = "Estado")]
        [StringLength(1, ErrorMessage ="La cantidad  maxima de caracateres valida es {1}")]
        [Range(1,9,ErrorMessage ="Los valores aceptados son del 1 al 9")]
        public string? estados {  get; set; }
    }
}
