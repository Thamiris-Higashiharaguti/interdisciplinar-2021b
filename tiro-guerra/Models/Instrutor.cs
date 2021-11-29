namespace TiroGuerra.Models
{
    public class Instrutor : Usuario
    {
        public string Graduacao { get; set; }

        #region Foreign Key
            public Usuario Usuario { get; set; }
        #endregion

    }
}