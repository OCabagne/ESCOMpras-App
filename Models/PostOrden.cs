
using System.Text.Json.Serialization;

namespace ESCOMpras.Models
{
    public partial class PostOrden
    {
        public DateTime Fecha { get; set; }
        public int Montototal { get; set; }
        public int ClienteIdcliente { get; set; }
        public int EscuelaIdescuela { get; set; }
        public int TiendaIdtienda { get; set; }
    }
}
