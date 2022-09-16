
namespace ESCOMpras.Models
{
    public partial class Escuela
    {
        public Escuela()
        {
            Clientes = new HashSet<Cliente>();
            Horaservicios = new HashSet<Horaservicio>();
            Ordens = new HashSet<Orden>();
        }

        public int Idescuela { get; set; }
        public string Nombre { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Horaservicio> Horaservicios { get; set; }
        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
