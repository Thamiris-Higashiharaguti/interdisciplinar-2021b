using System;
using System.Collections.Generic;
using TiroGuerra.Models;

namespace TiroGuerra.Repositories
{
    public interface IPelotaoRepository
    {
        void Create(Pelotao model);
        List<Pelotao> ReadAll();

    }
}
