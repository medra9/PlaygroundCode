using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace autenticacion.Models
{
    public class UserModel
    {
        [Required,
            DataType(DataType.EmailAddress),
            DisplayName("Usuario")]
        public string username { get; set; }
        [Required,
            DataType(DataType.Password)]
        public string password { get; set; }
        public string role { get; set; }
        [DisplayName("Imagen"),
            Description("Contiene el path de la imagen")]
        public string image_path { get; set; }
    }
}