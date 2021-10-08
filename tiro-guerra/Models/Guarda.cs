namespace TiroGuerra.Models
{
    public class Guarda
    {
        public int Id_Atirador { get; set; }
        public int Id_Guarnicao { get; set; }
        public string Funcao { get; set; }
        public bool Presenca { get; set; }

        #region Foreign Key
            public Atirador Atirador { get; set; }
        #endregion

        #region Foreign Key
            public Guarnicao Guarnicao { get; set; }
        #endregion
    }
}