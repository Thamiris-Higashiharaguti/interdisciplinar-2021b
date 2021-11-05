using System;
using System.Collections.Generic;
using TiroGuerra.Models;

namespace TiroGuerra.Repositories
{
    public interface IAtiradorRepository
    {
        void Create(Atirador model);
        List<Atirador> ReadAll();
        List<Atirador> ReadAllPelotoes();
        Atirador Read(int id);
        void Update(int id, Atirador model);
        void Delete(int id);

    }
}
