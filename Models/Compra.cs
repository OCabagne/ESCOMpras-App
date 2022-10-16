
using Newtonsoft.Json;

namespace ESCOMpras.Models
{
    public partial class Compra
    {
        public int Cantidad { get; set; }
        public string? descripcionproducto { get; set; } // *
        public string? Detalles { get; set; }
        public string nombreproducto { get; set; } = null!; // *
        public int precioproducto { get; set; } // *
        public string? promocion { get; set; } // *
        public string? unidad { get; set; } // *
        public int ProductoIdproducto { get; set; }
        public int OrdenIdorden { get; set; }
        
        [JsonIgnore] public virtual Orden OrdenIdordenNavigation { get; set; } = null!;
        [JsonIgnore] public virtual Producto ProductoIdproductoNavigation { get; set; } = null!;
    }
}
