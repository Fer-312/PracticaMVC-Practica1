using System.ComponentModel.DataAnnotations;
namespace PracticaMVC.Models
{
    public class estados_equipo
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
    }
}
