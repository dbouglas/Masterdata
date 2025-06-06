using System;

namespace Masterdata.Models
{
    public class Desembarque
    {
        public int Id { get; set; }
        public DateTime FechaGrabacion { get; set; }
        public string Referencia { get; set; }
        public bool Revisado { get; set; }
    }
}
