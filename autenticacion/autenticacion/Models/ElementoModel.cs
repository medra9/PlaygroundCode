using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace autenticacion.Models
{
    public class ElementoModel
    {
        public int id { get; set; }
        [Required]
        public string descripcion { get; set; }
        public bool edit { get; set; }
    }

    public class ElementoViewModel
    {
        public List<ElementoModel> lista { get; set; }
        public PrivilegeViewModel privilege { get; set; }
        public ElementoViewModel(List<ElementoModel> l, PrivilegeViewModel p)
        {
            lista = l;
            privilege = p;
        }
    }
}