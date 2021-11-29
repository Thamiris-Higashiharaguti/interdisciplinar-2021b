using TiroGuerra.Models;
using System.Collections.Generic;

namespace TiroGuerra.Models{
    public class ViewModel
    {
        public IEnumerable<Atirador> Atiradores { get; set; }
        public IEnumerable<Instrutor> Instrutores { get; set; }

        public IEnumerable<Guarda> Guardas { get; set; }

        public IEnumerable<Guarnicao> Guarnicoes { get; set; }

        public IEnumerable<Guarda> Comandantes { get; set; }

        public IEnumerable<Guarda> Cabos { get; set; }

        public IEnumerable<Guarda> Sentinelas { get; set; }

    }
}



