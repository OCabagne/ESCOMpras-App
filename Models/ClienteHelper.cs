using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCOMpras.Models
{
    internal class ClienteHelper
    {
        public bool Activo { get; set; }
        public int Calificacion { get; set; }
        public string Nombre { get; set; }
        public int EscuelaIdescuela { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }
}
