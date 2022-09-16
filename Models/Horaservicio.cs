
namespace ESCOMpras.Models
{
    public partial class Horaservicio
    {
        public int Idhoraservicio { get; set; }
        public short Day { get; set; }
        public short Horaentrada { get; set; }
        public short Horasalida { get; set; }
        public int EscuelaIdescuela { get; set; }
        public int TiendaIdtienda { get; set; }

        public virtual Escuela EscuelaIdescuelaNavigation { get; set; } = null!;
        public virtual Tiendum TiendaIdtiendaNavigation { get; set; } = null!;
    }
}
