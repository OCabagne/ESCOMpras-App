
namespace ESCOMpras.Models
{
    public partial class Reporte
    {
        public string? Descripcion { get; set; }
        public DateOnly Fecha { get; set; }
        public int ClienteIdcliente { get; set; }
        public int TiendaIdtienda { get; set; }

        public virtual Cliente ClienteIdclienteNavigation { get; set; } = null!;
        public virtual Tiendum TiendaIdtiendaNavigation { get; set; } = null!;
    }
}
