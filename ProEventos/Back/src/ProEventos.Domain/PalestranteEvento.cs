using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class PalestranteEventos
    {
        public int PalestranteId { get; set; }
        public Palestrante Palestrantes { get; set; }
        public int EventoId { get; set; }
        public Evento  Evento { get; set; }
    }
}