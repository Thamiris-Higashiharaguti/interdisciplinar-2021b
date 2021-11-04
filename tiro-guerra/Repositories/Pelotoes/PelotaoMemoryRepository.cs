using System;
using System.Collections.Generic;
using System.Linq;
using TiroGuerra.Models;

namespace TiroGuerra.Repositories
{
    // implementação do contrato ("Concreto")
    public class PelotaoMemoryRepository : IPelotaoRepository
    {
        private static List<Pelotao> pelotoes = new List<Pelotao>();

        public void Create(Pelotao model)
        {
            model.Id = 0; //Guid.NewGuid(); // uuid4 (no npm)
            pelotoes.Add(model);
        }        

        public List<Pelotao> ReadAll()
        {
            return pelotoes;
        }
    }
}