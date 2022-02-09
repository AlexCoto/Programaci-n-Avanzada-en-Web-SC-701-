using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public partial class Feedback
    {
        public Feedback()
        {
            Vuelos = new HashSet<Vuelo>();
        }

        public int FeedbackId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Message { get; set; } = null!;
        public bool ContactMe { get; set; }

        public virtual ICollection<Vuelo> Vuelos { get; set; }
    }
}
