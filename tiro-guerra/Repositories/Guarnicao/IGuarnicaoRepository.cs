using System;
using System.Collections.Generic;
using TiroGuerra.Models;

namespace TiroGuerra.Repositories
{
    public interface IGuarnicaoRepository
    {
        void Create(Guarnicao model);
        Guarnicao Read(int id);
        void Update(int id, Guarnicao model);

        void Delete(int id);
    }
}