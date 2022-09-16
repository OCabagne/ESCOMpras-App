
namespace ESCOMpras.Models
{
    public partial class Ingreso
    {
        public int Id { get; set; }
        public DateOnly? Fecha { get; set; }
        public int Idusuario { get; set; }
        public string? Ip { get; set; }
        public bool Iscliente { get; set; }
    }
}
