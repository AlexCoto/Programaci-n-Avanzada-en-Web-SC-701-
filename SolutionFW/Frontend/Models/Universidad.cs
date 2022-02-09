using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public partial class Universidad
    {
        public Universidad()
        {
            Carreras = new HashSet<Carrera>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime? Fundacion { get; set; }
        public string? Dominio { get; set; }

        public virtual ICollection<Carrera> Carreras { get; set; }
    }
}
