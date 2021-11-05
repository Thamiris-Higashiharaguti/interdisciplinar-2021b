namespace TiroGuerra.Models
{
    public class Instrutor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public bool Status  { get; set; } = true;
        public string Graduacao { get; set; }

    }
}