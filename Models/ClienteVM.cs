
namespace ESCOMpras.Models
{
    public class ClienteVM
    {
        public int Idcliente { get; set; }
        public int Calificacion { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int EscuelaIdescuela { get; set; }
        public string Url { get; set; } = null!;
        public string nombreEscuela { get; set; }
        public ClienteVM(int idCliente, int calificacion, string nombre, string apellidos, string correo, string password, int idEscuela)
        {
            this.Idcliente = idCliente;
            this.Calificacion = calificacion;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Correo = correo;
            this.Password = password;
            this.EscuelaIdescuela = idEscuela;
            completar(idEscuela);
        }

        private async void completar(int idEscuela)
        {
            this.nombreEscuela = await internetEscompras.GetNombreEscuela(idEscuela);
        }
    }
}
