
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

        public int Id_Pelotao { get; set; }
        public string Formacao { get; set; }
        public string RA { get; set; }
        public date GDA_Vermelha { get; set; }
        public date GDA_Preta { get; set; }
        public string Numero { get; set; }

        #region Foreign Key
            public Pelotao Pelotao { get; set; }
        #endregion
    }
}