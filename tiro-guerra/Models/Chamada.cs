namespace TiroGuerra.Models
{
    public class Chamada
    {
        public int Id_Atirador { get; set; }
        public int Id_Instrucao { get; set; }
        public int Id_Responsavel { get; set; }
        public bool Presenca { get; set; }

        #region Foreign Key
            public Atirador Atirador { get; set; }
        #endregion

        #region Foreign Key
            public Instrucao Instrucao { get; set; }
        #endregion

        #region Foreign Key
            public Atirador Responsavel { get; set; }
        #endregion
    }
}