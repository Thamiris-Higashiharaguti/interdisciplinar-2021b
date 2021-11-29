using System;
namespace TiroGuerra.Models
{
    //atirador
    public class Atirador : Usuario
    {
        
        public int IdPelotao { get; set; }
        public string Formacao { get; set; }
        public string RA { get; set; }
        public DateTime GDAVermelha { get; set; }
        public DateTime GDAPreta { get; set; }
        public string Numero { get; set; }

        #region Foreign Key
            public Pelotao Pelotao { get; set; }
        #endregion
        #region Foreign Key
            public Usuario Usuario { get; set; }
        #endregion
    }
}