using System;
using System.Collections.Generic;
using TiroGuerra.Models;

namespace TiroGuerra.Repositories
{
    public interface IGuarnicaoRepository
    {
        Guarnicao Create(List<Guarda> model);

        Guarnicao Read(int id);

        void Update(int id, Guarnicao model);

        void Delete(int id);
    }
}