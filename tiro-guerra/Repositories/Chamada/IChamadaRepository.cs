using System;
using System.Collections.Generic;
using TiroGuerra.Models;

namespace TiroGuerra.Repositories
{
    public interface IChamadaRepository
    {
        void Create(int Id_Atirador,int Id_Responsavel, bool Presenca);
        List<Chamada> ReadAll();

    }
}
