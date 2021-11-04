using System;
using System.Collections.Generic;
using System.Linq;
using TiroGuerra.Models;

namespace TiroGuerra.Repositories
{
    // implementação do contrato ("Concreto")
    public class AtiradorMemoryRepository : IAtiradorRepository
    {
        private static List<Atirador> atiradores = new List<Atirador>();

        public void Create(Atirador model)
        {
            model.Id = 0; //Guid.NewGuid(); // uuid4 (no npm)
            atiradores.Add(model);
        }        

        public List<Atirador> ReadAll()
        {
            return atiradores;
        }
        public List<Atirador> ReadAllPelotoes()
        {
            return atiradores;
        }

        public Atirador Read(int id)
        {
            return atiradores.Single(atirador => atirador.Id == id);
        }

        public void Update(int id, Atirador model)
        {
            var atirador = atiradores.Single(x => x.Id == id);
            atirador.Nome = model.Nome;
            atirador.CPF = model.CPF;
            atirador.RG = model.RG;
            atirador.Status = model.Status;
            atirador.Senha = model.Senha;
            atirador.IdPelotao = model.IdPelotao;
            atirador.Formacao = model.Formacao;
            atirador.RA = model.RA;
            atirador.GDAVermelha = model.GDAVermelha;
            atirador.GDAPreta = model.GDAPreta;
            atirador.Numero = model.Numero;
        }

        public void Delete(int id)
        {
            var atirador = atiradores.Single(atirador => atirador.Id == id);
            atiradores.Remove(atirador);
        }
    }
}