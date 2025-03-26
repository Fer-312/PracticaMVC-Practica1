using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PracticaMVC.Models
{
    public class equipos
    {
        [Key]
        public int id_equipo { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        //[ForeignKey("TipoEquipo")]
        public int tipo_equipo_id { get; set; }

        //[ForeignKey("Marca")]
        public int marca_id { get; set; }

        public string modelo { get; set; }

        public int? anio_compra { get; set; }

        public int? vida_util { get; set; } 

        //[Column(TypeName = "decimal(10,2)")]
        public decimal? costo { get; set; }

        //[ForeignKey("EstadoEquipo")]
        public int estado_equipo_id { get; set; }

        public bool inactivo { get; set; } = false;

    }
}
