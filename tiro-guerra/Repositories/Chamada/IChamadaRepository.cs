using System;
using System.Collections.Generic;
using TiroGuerra.Models;

namespace TiroGuerra.Repositories
{
    public interface IChamadaRepository
    {
        void Create(List<Chamada> model,int Id_Responsavel);
        List<Chamada> ReadByPelotao( int Id_Pelotao);
        List<Chamada> ReadAll();
        
    }
}
