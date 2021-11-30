using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using TiroGuerra.Models;
using TiroGuerra.Repositories;
using TiroGuerra.Controllers;
using System.Linq;
using Microsoft.VisualBasic;
using System.Windows;

namespace TiroGuerra.Controllers
{
    public class GuarnicaoController:Controller
    {
        private IAtiradorRepository atirador_repository;
        private IInstrutorRepository instrutor_repository;
        private IGuarnicaoRepository guarnicaoRepository;
        private IGuardaRepository guardaRepository;
        public GuarnicaoController(IAtiradorRepository atirador_repository,  IGuarnicaoRepository guarnicaoRepository, IInstrutorRepository instrutor_repository, IGuardaRepository guarda_repository) 
        {
            this.atirador_repository = atirador_repository;
            this.guarnicaoRepository = guarnicaoRepository;
            this.instrutor_repository = instrutor_repository;
            this.guardaRepository = guarda_repository;
        }
        public string MesAtual(DateTime date)
        {
            string mes;
            switch(date.Month)
            {
                case 1:
                mes = "Janeiro";
                break;
                case 2:
                mes = "Fevereiro";
                break;  
                case 3:
                mes = "Março";
                break;  
                case 4:
                mes = "Abril";
                break;  
                case 5:
                mes = "Maio";
                break;  
                case 6:
                mes = "Junho";
                break;  
                case 7:
                mes = "Julho";
                break;  
                case 8:
                mes = "Agosto";
                break;  
                case 9:
                mes = "Setembro";
                break;  
                case 10:
                mes = "Outubro";
                break;  
                case 11:
                mes = "Novembro";
                break;  
                default:
                mes = "Dezembro";
                break;     
            }
            return mes;
        }
        public List<DateTime> GetFirstLastDayWeek(DateTime day)
        {
            List<DateTime> dias = new List<DateTime>();
            DateTime sabado = new DateTime();
            DateTime domingo = new DateTime();
            while (true)
            {
                if(day.DayOfWeek==DayOfWeek.Sunday)
                {
                  
                    domingo = day;
                    break;
                }
                else
                {
                    day = day.AddDays(-1);
                }
                 
            }
            
            sabado = domingo.AddDays(6);
            dias.Add(sabado);
            dias.Add(domingo);
            return dias;
        }
        [HttpGet]
        public ActionResult index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult create(DateTime dataCriar)
        {
            ViewBag.data = dataCriar.ToString("MM/dd/yyyy");
            ViewBag.mes = MesAtual(dataCriar);
            var atiradores = atirador_repository.ReadAll();
            var instrutores = instrutor_repository.ReadAll();
           
            ViewModel mymodel = new ViewModel();
            mymodel.Instrutores = instrutores;
            mymodel.Atiradores = atiradores; 
            return View(mymodel);
            
        }
        [HttpPost]
        public ActionResult create(List<int> id,  List<string> Funcao, List<DateTime> dataDia, List<int> idfiscal)
        {   
            List<Guarda> Guardas = new List<Guarda>();
            for(int i = 0; i<id.Count(); i++)
            {
                Guardas.Add(new Guarda{
                    IdAtirador = id[i],
                    Funcao = Funcao[i]
                    }
                );
            }
            List<Guarnicao> Guarnicoes = new List<Guarnicao>();
   
            Guarnicoes=guarnicaoRepository.Create(idfiscal, dataDia);
            guardaRepository.Create(Guardas,Guarnicoes);
             return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Update(DateTime dataAlterar)
        {
            
            List<DateTime> listDias = new List<DateTime>();
            DateTime sabado = new DateTime();
            DateTime domingo = new DateTime();
            listDias = GetFirstLastDayWeek(dataAlterar);

            sabado = listDias[0];
            domingo = listDias[1];

            List<Guarda> Guardas =  new List<Guarda>();
            Guardas = guardaRepository.Read(domingo,sabado);

            List<Guarnicao> Guarnicoes = new List<Guarnicao>();
            Guarnicoes = guarnicaoRepository.Read(domingo,sabado);


            List<Guarda> Cabos = new List<Guarda>();
            List<Guarda> Comandantes = new List<Guarda>();
            List<Guarda> Sentinelas = new List<Guarda>();
            //Console.WriteLine(Guardas[0].IdAtirador)
            for(int i =0; i<Guardas.Count; i++)
            {   
               if(Guardas[i].Funcao=="Cabo")
               {
                   Cabos.Add(new Guarda{
                        Id = Guardas[i].Id,
                        IdAtirador = Guardas[i].IdAtirador,
                        Atirador = Guardas[i].Atirador
                   });
               }
               
             else if(Guardas[i].Funcao=="Comandante")
               {
                   Comandantes.Add(new Guarda{
                        Id = Guardas[i].Id,
                        IdAtirador = Guardas[i].IdAtirador,
                        Atirador = Guardas[i].Atirador
                   });
                   
               }
               else{
                    Sentinelas.Add(new Guarda{
                        Id = Guardas[i].Id,
                        IdAtirador = Guardas[i].IdAtirador,
                        Atirador = Guardas[i].Atirador
                   });
               } 
                
            }
            ViewModel mymodel = new ViewModel();
            mymodel.Cabos = Cabos;
            mymodel.Comandantes = Comandantes;
            mymodel.Sentinelas = Sentinelas; 
            mymodel.Guarnicoes = Guarnicoes; 
          //  mymodel.Guardas = Guardas;
            var atiradores = atirador_repository.ReadAll();
            var instrutores = instrutor_repository.ReadAll();
           
            mymodel.Instrutores = instrutores;
            mymodel.Atiradores = atiradores; 
            ViewBag.mes = MesAtual(sabado);

            if(Guarnicoes.Count <7)
            {
         
              ViewData["Message"] = "Erro ao procurar";
               return  View("index");
            }
            
            return View(mymodel);
        }

        [HttpPost]
        public ActionResult Update(List<int> idGuarnicao, List<int> idfiscal, List<int> idGuarda, List<int> IdAtirador)
        {
            Console.WriteLine("Quantidade de Guarniçoes "+idGuarnicao.Count);
            Console.WriteLine("Quantidade de idFiscal "+idfiscal.Count);
            Console.WriteLine("Quantidade de idGuarda "+idGuarda.Count);
            Console.WriteLine("Quantidade de IdAtirador "+IdAtirador.Count);

            List<Guarnicao> Guarnicoes = new List<Guarnicao>();
            List<Guarda> Guardas = new List<Guarda>();

            for(int i =0; i<idGuarnicao.Count; i++)
            {
                Guarnicoes.Add(new Guarnicao{
                    Id = idGuarnicao[i],
                    Id_Instrutor = idfiscal[i]
                });
            }

            for(int i = 0; i<idGuarda.Count; i++)
            {
                Guardas.Add(new Guarda{
                    Id = idGuarda[i],
                    IdAtirador = IdAtirador[i]
                });
            }

            guarnicaoRepository.Update(Guarnicoes);
            guardaRepository.Update(Guardas);

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult escalaGuarda()
        {
            DateTime dateNow = DateTime.Today;
            List<DateTime> listDias = new List<DateTime>();
            DateTime sabado = new DateTime();
            DateTime domingo = new DateTime();
            listDias = GetFirstLastDayWeek(dateNow);
            sabado = listDias[0];
            domingo = listDias[1];
            List<Guarda> Guardas =  new List<Guarda>();
            Guardas = guardaRepository.Read(domingo,sabado);
            List<Guarnicao> Guarnicoes = new List<Guarnicao>();
            Guarnicoes = guarnicaoRepository.Read(domingo,sabado);
            List<Guarda> Cabos = new List<Guarda>();
            List<Guarda> Comandantes = new List<Guarda>();
            List<Guarda> Sentinelas = new List<Guarda>();
            for(int i =0; i<Guardas.Count; i++)
            {   
               if(Guardas[i].Funcao=="Cabo")
               {
                   Cabos.Add(new Guarda{
                        Id = Guardas[i].Id,
                        IdAtirador = Guardas[i].IdAtirador,
                        Atirador = Guardas[i].Atirador
                   });
               }
               
             else if(Guardas[i].Funcao=="Comandante")
               {
                   Comandantes.Add(new Guarda{
                        Id = Guardas[i].Id,
                        IdAtirador = Guardas[i].IdAtirador,
                        Atirador = Guardas[i].Atirador
                   });
                   
               }
               else{
                    Sentinelas.Add(new Guarda{
                        Id = Guardas[i].Id,
                        IdAtirador = Guardas[i].IdAtirador,
                        Atirador = Guardas[i].Atirador
                   });
               } 
                
            }
            ViewModel mymodel = new ViewModel();
            mymodel.Cabos = Cabos;
            mymodel.Comandantes = Comandantes;
            mymodel.Sentinelas = Sentinelas; 
            mymodel.Guarnicoes = Guarnicoes; 
            var atiradores = atirador_repository.ReadAll();
            var instrutores = instrutor_repository.ReadAll();
           
           mymodel.Instrutores = instrutores;
           mymodel.Atiradores = atiradores; 

            if(Guarnicoes.Count <7)
            {
        
                ViewData["Message"] = "Faça o cadastro da guarnição antes de tentar altera-la";
                return RedirectToAction("Index", "Guarnicao");
            }

            ViewBag.mes = MesAtual(sabado);
            return View(mymodel);
        }
    }
}