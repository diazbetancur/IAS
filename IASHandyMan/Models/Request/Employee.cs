using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ALPHA.Models.Request
{
    public class Employee
    {
        [Display(Name = "Usuario de empleado")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string user { get; set; }

        [Display(Name = "Contraseña de empleado")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [DataType(DataType.Password)]
        public string pass { get; set; }

        public int idRol { get; set; }
    }
}