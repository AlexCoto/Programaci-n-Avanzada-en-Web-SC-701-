using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public partial class Vuelo
    {
        public int IId { get; set; }
        public string NNombreAvion { get; set; } = null!;
        public int ICantidadPasajeros { get; set; }
        public int ITipoPasajero { get; set; }
        public DateTime DtSalidadViaje { get; set; }
        public DateTime DtDestinoViaje { get; set; }
        public decimal DPesoMaximoMaletas { get; set; }
        public DateTime DtHoraSalida { get; set; }
        public DateTime DtHoraLlegada { get; set; }
        public string VAerolinea { get; set; } = null!;
        public bool BActivo { get; set; }
        public decimal DValoracionUsuarios { get; set; }
        public int? IFeedback { get; set; }

        public virtual Feedback? IFeedbackNavigation { get; set; }
    }
}
