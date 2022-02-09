using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public partial class Carrera
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? GradoAcademico { get; set; }
        public bool? AcreditadaSinaes { get; set; }
        public DateTime? Creacion { get; set; }
        public string? Decano { get; set; }
        public int? Precio { get; set; }
        public string? RequisitoGraduacion { get; set; }
        public bool? Desactivado { get; set; }
        public int? IdUniversidad { get; set; }

        public virtual Universidad? IdUniversidadNavigation { get; set; }
    }
}
