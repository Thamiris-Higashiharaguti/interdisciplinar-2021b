namespace TiroGuerra.Models
{
    public class Instrutor
    {
        public string Graduacao { get; set; }

        public string Senha {get; set;}

        #region Foreign Key
            public Usuario Usuario { get; set; }
        #endregion

    }
}