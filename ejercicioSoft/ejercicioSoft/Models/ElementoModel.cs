using System.ComponentModel.DataAnnotations;

namespace ejercicioSoft.Models
{
    public class ElementoModel
    {
        public int id { get; set; }
        [Required]
        public string descripcion { get; set; }
    }
}