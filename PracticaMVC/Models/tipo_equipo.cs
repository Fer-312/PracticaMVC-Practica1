using System.ComponentModel.DataAnnotations;

namespace PracticaMVC.Models
{
    public class tipo_equipo
    {
        [Key]
        public int equipo_id { get; set; }
        public string? nombre { get; set; }
    }
}
