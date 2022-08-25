using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int Precio { get; set; }
        public string Url { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
