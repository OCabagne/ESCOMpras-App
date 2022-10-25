
using Newtonsoft.Json;

namespace ESCOMpras.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Tienda = new HashSet<Tiendum>();
        }

        public int Idtipo { get; set; }
        public string Nombre { get; set; } = null!;
        [JsonIgnore] public string Imagen { get; set; }
        public virtual ICollection<Tiendum> Tienda { get; set; }
    }
}
