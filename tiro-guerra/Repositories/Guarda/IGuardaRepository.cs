using System;
using System.Collections.Generic;
using TiroGuerra.Models;

namespace TiroGuerra.Repositories
{
    public interface IGuardaRepository
    {
        void Create(List<Guarda> guardas, List<Guarnicao> guarnicoes);

        Guarda Read(int id);

        void Update(int id, Guarda model);

        void Delete(int id);
    }
}