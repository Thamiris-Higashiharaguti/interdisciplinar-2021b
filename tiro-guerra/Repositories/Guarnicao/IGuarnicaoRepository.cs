using System;
using System.Collections.Generic;
using TiroGuerra.Models;

namespace TiroGuerra.Repositories
{
    public interface IGuarnicaoRepository
    {
        List<Guarnicao> Create(List<int> idfiscal, List<DateTime> dias);

        Guarnicao Read(int id);

        void Update(int id, Guarnicao model);

        void Delete(int id);
    }
}