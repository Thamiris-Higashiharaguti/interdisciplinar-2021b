using System;
namespace TiroGuerra.Models
{
    //Usuario
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public bool Status { get; set; } = true;
        public string Senha { get; set; }
        
    }
}