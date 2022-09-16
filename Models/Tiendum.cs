
namespace ESCOMpras.Models
{
    public partial class Tiendum
    {
        public Tiendum()
        {
            Horaservicios = new HashSet<Horaservicio>();
            Ordens = new HashSet<Orden>();
            Productos = new HashSet<Producto>();
            ClienteIdclientes = new HashSet<Cliente>();
        }

        public int Idtienda { get; set; }
        public string Nombre { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;
        public int TipoIdtipo { get; set; }
        public string Correo { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Imagen { get; set; }

        public virtual Tipo TipoIdtipoNavigation { get; set; } = null!;
        public virtual Comentario Comentario { get; set; } = null!;
        public virtual Reporte Reporte { get; set; } = null!;
        public virtual ICollection<Horaservicio> Horaservicios { get; set; }
        public virtual ICollection<Orden> Ordens { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }

        public virtual ICollection<Cliente> ClienteIdclientes { get; set; }
    }
}
