using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.Models
{
    [QueryProperty("Producto", "Producto")]
    public partial class ProductoVM
    {
        public ProductoVM()
        {
            
        }

        Producto producto;
    }
}
