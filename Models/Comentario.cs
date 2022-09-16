
namespace ESCOMpras.Models
{
    public partial class Comentario
    {
        public string? Comentario1 { get; set; }
        public int ClienteIdcliente { get; set; }
        public int TiendaIdtienda { get; set; }

        public virtual Cliente ClienteIdclienteNavigation { get; set; } = null!;
        public virtual Tiendum TiendaIdtiendaNavigation { get; set; } = null!;
    }
}
