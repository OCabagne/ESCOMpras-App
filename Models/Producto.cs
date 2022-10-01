
namespace ESCOMpras.Models
{
    public partial class Producto
    {
        public int Idproducto { get; set; }
        public int Cantidad { get; set; }
        public string? Descripcion { get; set; }
        public string? Nombre { get; set; }
        public int Precio { get; set; }
        public string? Promocion { get; set; }
        public string? Unidad { get; set; }
        public int TiendaIdtienda { get; set; }
        public string? Imagen { get; set; }

        public virtual Tiendum? TiendaIdtiendaNavigation { get; set; }
        public virtual Compra Compra { get; set; } = null!;
    }
}
