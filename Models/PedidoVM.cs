using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCOMpras.Models
{
    public class PedidoVM
    {
        public string NombreProducto { get; set; }
        public int idProducto { get; set; }
        public int PrecioProducto { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }
        public int idTienda { get; set; }
        public string Horario { get; set; }

        public string NombreEscuela { get; set; }

        // idCliente
        // idEscuela
    }
}
