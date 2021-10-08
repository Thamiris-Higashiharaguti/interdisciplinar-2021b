namespace TiroGuerra.Models
{
    public class Guarnicao
    {
        public int Id { get; set; }
        public int IdInstrutor { get; set; }
        public date Data { get; set; }

        #region Foreign Key
            public Instrutor Instrutor { get; set; }
        #endregion
    }
}