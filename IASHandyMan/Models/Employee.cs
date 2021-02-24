using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IASHandyMan.Models
{
    public class Employee
    {
        [Display(Name = "Número de empleado")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int Employeeid { get; set; }

        [Display(Name = "Contraseña de empleado")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [DataType(DataType.Password)]
        public string pass { get; set; }
    }
}