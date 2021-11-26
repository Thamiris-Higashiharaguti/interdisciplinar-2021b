using Microsoft.AspNetCore.Http;

namespace TiroGuerra.Models
{
    public class Guarda
    {
        public int IdAtirador { get; set; }
        public int IdGuarnicao { get; set; }
        public string Funcao { get; set; }
        public bool Presenca { get; set; }

        #region Foreign Key
            public Atirador Atirador { get; set; }
        #endregion

    }
}