using System;
using System.Collections.Generic;
using TiroGuerra.Models;

namespace TiroGuerra.Repositories
{
    public interface IInstrutorRepository
    {
        void Create(Instrutor model);
        Instrutor Read(int id);
        void Update(int id, Instrutor model);

        void Delete(int id);

        List<Instrutor> readFiltro(string nome);

        List<Instrutor> ReadAll();
    }
}