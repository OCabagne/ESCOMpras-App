
namespace ESCOMpras.Models
{
    public partial class Orden
    {
        public Orden()
        {
            Compras = new HashSet<Compra>();
        }

        public int Idorden { get; set; }
        public DateOnly Fecha { get; set; }
        public int Montototal { get; set; }
        public int ClienteIdcliente { get; set; }
        public int EscuelaIdescuela { get; set; }
        public int TiendaIdtienda { get; set; }

        public virtual Cliente ClienteIdclienteNavigation { get; set; } = null!;
        public virtual Escuela EscuelaIdescuelaNavigation { get; set; } = null!;
        public virtual Tiendum TiendaIdtiendaNavigation { get; set; } = null!;
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
