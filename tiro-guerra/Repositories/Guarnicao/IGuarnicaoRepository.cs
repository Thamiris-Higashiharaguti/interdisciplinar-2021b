using System;
using System.Collections.Generic;
using TiroGuerra.Models;

namespace TiroGuerra.Repositories
{
    public interface IGuarnicaoRepository
    {
        List<Guarnicao> Create(List<int> idfiscal, List<DateTime> dias);

        List<Guarnicao> Read(DateTime domingo, DateTime sabado);

        void Update(int id, Guarnicao model);

        void Delete(int id);
    }
}