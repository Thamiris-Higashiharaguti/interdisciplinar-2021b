using System;
namespace TiroGuerra.Models
{
    public class Guarnicao
    {
        public int Id { get; set; }
        public int Id_Instrutor { get; set; }
        public DateTime Data { get; set; }

        //public List<Guarda> Guardas { get; set; }

        #region Foreign Key
            public Instrutor Instrutor { get; set; }
        #endregion
    }
}