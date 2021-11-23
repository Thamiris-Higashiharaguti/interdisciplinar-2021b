using System;
using System.Collections.Generic;
using TiroGuerra.Models;

namespace TiroGuerra.Repositories
{
    public interface IUsuarioRepository
    {
 
        Atirador Read(string CPF, string RA);


    }
}
