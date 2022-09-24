
namespace ESCOMpras.Models
{
	public class PedidoPendiente
	{
		public int ProductoIdproducto { get; set; } // * constructor
		public int ClienteIdcliente { get; set; } // * constructor
        public int EscuelaIdescuela { get; set; } // * constructor
        public int TiendaIdtienda { get; set; } // * constructor

        // -- Data to display
        public int Idorden { get; set; } // * constructor
        public int Cantidad { get; set; } // * constructor
		public string? Detalles { get; set; } // * constructor
        public DateTime Fecha { get; set; }	// * constructor
		public int Montototal { get; set; } // * constructor
        public Producto producto { get; set; }	// internetEscompras.GetProducto(idProducto);
		public string nombreEscuela { get; set; }	// internetEscompras.GetNombreEscuela(idEscuela);
		public string nombreCliente { get; set; }	// internetEscompras.GetNombreCliente(idCliente);
		public string nombreTienda { get; set; }	// internetEscompras.GetNombreTienda(idTienda)

		public PedidoPendiente() { }

		public PedidoPendiente(int productoIdproducto, int clienteIdcliente, int escuelaIdescuela, int tiendaIdtienda, int idOrden, int cantidad, string detalles, DateTime fecha, int montoTotal)
		{
			this.ProductoIdproducto = productoIdproducto;
			this.ClienteIdcliente = clienteIdcliente;
			this.EscuelaIdescuela = escuelaIdescuela;
			this.TiendaIdtienda = tiendaIdtienda;
			this.Idorden = idOrden;
			this.Cantidad = cantidad;
			this.Detalles = detalles;
			this.Fecha = fecha;
			this.Montototal = montoTotal;

			Completar();
		}

		private async void Completar()
		{
			var producto = await internetEscompras.GetProducto(ProductoIdproducto);
			producto.Imagen = "https://www.arraymedical.com/wp-content/uploads/2018/12/product-image-placeholder.jpg";
			this.producto = producto;
            this.nombreEscuela = await internetEscompras.GetNombreEscuela(EscuelaIdescuela);
			this.nombreCliente = await internetEscompras.GetNombreCliente(ClienteIdcliente);
			this.nombreTienda = await internetEscompras.GetNombreTienda(TiendaIdtienda);
		}

	}
}
