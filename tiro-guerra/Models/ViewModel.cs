using TiroGuerra.Models;
using System.Collections.Generic;

namespace TiroGuerra.Models{
    public class ViewModel
    {
        public IEnumerable<Atirador> Atiradores { get; set; }
        public IEnumerable<Instrutor> Instrutores { get; set; }
    }
}



