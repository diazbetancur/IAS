//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ALPHA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblRadication
    {
        public int id { get; set; }
        public bool type { get; set; }
        public int idSender { get; set; }
        public int idReceiver { get; set; }
        public string idRadication { get; set; }
        public int idDocument { get; set; }
        public Nullable<System.DateTime> dateRadication { get; set; }
    
        public virtual tblDocuments tblDocuments { get; set; }
        public virtual tblPerson tblPerson { get; set; }
        public virtual tblPerson tblPerson1 { get; set; }
    }
}
