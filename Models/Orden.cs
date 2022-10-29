using Newtonsoft.Json;


namespace ESCOMpras.Models
{
    public partial class Orden
    {
        public Orden()
        {
            Compras = new HashSet<Compra>();
        }

        [JsonIgnore] public int Idorden { get; set; }
        public DateTime Fecha { get; set; }
        public int Montototal { get; set; }
        public int ClienteIdcliente { get; set; }
        public int EscuelaIdescuela { get; set; }
        public int TiendaIdtienda { get; set; }
        public string? Estado { get; set; }     //*
        public int? HoraentregaIdhoraservicio { get; set; }     //*

        [JsonIgnore] public virtual Cliente ClienteIdclienteNavigation { get; set; } = null!;
        [JsonIgnore] public virtual Escuela EscuelaIdescuelaNavigation { get; set; } = null!;
        [JsonIgnore] public virtual Horaservicio? HoraentregaIdhoraservicioNavigation { get; set; }
        [JsonIgnore] public virtual Tiendum TiendaIdtiendaNavigation { get; set; } = null!;
        [JsonIgnore] public virtual ICollection<Compra> Compras { get; set; }
    }
}
