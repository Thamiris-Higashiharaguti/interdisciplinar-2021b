using System;
using System.Collections.Generic;
using TiroGuerra.Models;

namespace TiroGuerra.Repositories
{
    public interface IGuardaRepository
    {
        void Create(List<Guarda> guardas, List<Guarnicao> guarnicoes);

        List<Guarda> Read(DateTime domingo, DateTime sabado);

        void Update(List<Guarda> model);

        void Delete(int id);
    }
}