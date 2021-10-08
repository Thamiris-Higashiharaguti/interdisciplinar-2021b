namespace TiroGuerra.Models
{
    public class Chamada
    {
        public int IdAtirador { get; set; }
        public int IdInstrucao { get; set; }
        public int IdResponsavel { get; set; }
        public bool Presenca { get; set; }

        #region Foreign Key
            public Atirador Atirador { get; set; }
        #endregion

        #region Foreign Key
            public Atirador Responsavel { get; set; }
        #endregion
    }
}