
namespace ESCOMpras.Models
{
    public partial class Compra
    {
        public int Cantidad { get; set; }
        public string? Detalles { get; set; }
        public int ProductoIdproducto { get; set; }
        public int OrdenIdorden { get; set; }

        public virtual Orden OrdenIdordenNavigation { get; set; } = null!;
        public virtual Producto ProductoIdproductoNavigation { get; set; } = null!;
    }
}
