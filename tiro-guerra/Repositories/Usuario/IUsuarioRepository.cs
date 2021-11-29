using System;
using System.Collections.Generic;
using TiroGuerra.Models;

namespace TiroGuerra.Repositories
{
    public interface IUsuarioRepository
    {

        Usuario Read(string CPF, string Senha);


    }
}
