using System;
using System.Collections.Generic;
using TiroGuerra.Models;

namespace TiroGuerra.Repositories
{
    public interface IChamadaRepository
    {
        void Create(Chamada model,int Id_Responsavel);
        List<Chamada> ReadAll();

    }
}
