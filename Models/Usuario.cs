
namespace ESCOMpras.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Escuela { get; set; }
        public string Url { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
