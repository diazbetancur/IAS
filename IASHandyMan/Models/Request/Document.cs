using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ALPHA.Models.Request
{
    public class Document
    {
        public int id { get; set; }

        [Display(Name = "Nombre del Archivo")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string nameFile { get; set; }
        public string consecutivo { get; set; }
        public string realName { get; set; }
        public string fileExt { get; set; }

        [Display(Name = "Tipo de Comunucacion")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string typeDocument { get; set; }
        [Display(Name = "Numero documento quien envia")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int idSender { get; set; }
        [Display(Name = "Numero documento quien recibe")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int idReceiver { get; set; }
        public string idRadication { get; set; }
        public string pathFile { get; set; }
        public HttpPostedFileBase documentFile { get; set; }
    }
}