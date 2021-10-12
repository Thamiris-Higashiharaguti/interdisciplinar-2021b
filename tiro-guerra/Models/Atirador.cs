using System;
namespace TiroGuerra.Models
{
    //atirador
    public class Atirador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public bool Status { get; set; }
        public string Senha { get; set; }
        public int IdPelotao { get; set; }
        public string Formacao { get; set; }
        public string RA { get; set; }
        public DateTime GDAVermelha { get; set; }
        public DateTime GDAPreta { get; set; }
        public string Numero { get; set; }

        #region Foreign Key
            public Pelotao Pelotao { get; set; }
        #endregion
    }
}