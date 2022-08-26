using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Escuela { get; set; }
        public string Url { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
