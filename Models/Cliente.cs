
namespace ESCOMpras.Models
{
    public partial class Cliente
    {
        
        public Cliente()
        {
            Ordens = new HashSet<Orden>();
            FavoritosIdtienda = new HashSet<Tiendum>();
        }

        public int Idcliente { get; set; }
        public bool Activo { get; set; }
        public int Calificacion { get; set; }
        public string Nombre { get; set; } = null!;
        public int EscuelaIdescuela { get; set; }
        public string Apellidos { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Password { get; set; } = null!;

        public string Url { get; set; } = null!;

        public virtual Escuela EscuelaIdescuelaNavigation { get; set; } = null!;
        public virtual Comentario Comentario { get; set; } = null!;
        public virtual Reporte Reporte { get; set; } = null!;
        public virtual ICollection<Orden> Ordens { get; set; }
        public virtual ICollection<Tiendum> FavoritosIdtienda { get; set; }
    }
}
