
namespace ESCOMpras.Models
{
    internal class OrdenVM
    { 
        public int Idorden { get; set; }
        public DateTime Fecha { get; set; }
        public int Montototal { get; set; }
        public int ClienteIdcliente { get; set; }
        public int EscuelaIdescuela { get; set; }
        public int TiendaIdtienda { get; set; }
        public string Estado { get; set; }
    }
}
