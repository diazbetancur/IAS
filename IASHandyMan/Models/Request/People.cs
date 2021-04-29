using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALPHA.Models.Request
{
    public class People
    {
        public int id { get; set; }
        public string names { get; set; }
        public string lastName { get; set; }
        public string nameComplet { get; set; }
        public string mail { get; set; }

        public int idRol { get; set; }
    }
}