using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using TiroGuerra.Models;
using System.Linq;
using TiroGuerra.Repositories;
using TiroGuerra.Controllers;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace TiroGuerra.Controllers
{
    public class UsuarioController:Controller
    {
        private IUsuarioRepository repository;
        private IInstrutorRepository Instrutorrepository;
        private IAtiradorRepository Atiradorrepository;

        public UsuarioController(IUsuarioRepository repository,IInstrutorRepository Instrutorrepository,IAtiradorRepository Atiradorrepository) 
        {
            this.repository = repository;
            this.Instrutorrepository = Instrutorrepository;
            this.Atiradorrepository = Atiradorrepository;
        }

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuario model)
        {
            Usuario usuario = repository.Read(model.CPF, model.Senha);
            if(usuario == null)
            {
                Console.WriteLine("Usuário não encontrado.");
                return View();
            }


            try{
                
                try{
                    Instrutor instrutor = Instrutorrepository.Read(usuario.Id);
                
                    if(instrutor == null)
                    {
                        Console.WriteLine("Usuário não encontrado.");
                    }else{
                        HttpContext.Session.SetInt32("Id", (int)instrutor.Id); 
                        HttpContext.Session.SetString("Nome", instrutor.Nome); 
                        HttpContext.Session.SetString("CPF", instrutor.CPF); 
                        HttpContext.Session.SetString("RG", instrutor.RG); 
                        HttpContext.Session.SetString("Email", instrutor.Email); 
                        HttpContext.Session.SetString("Graduacao", instrutor.Graduacao); 
                        return RedirectToAction("Index", "Home");
                    }
                }catch{
                    Atirador atirador = Atiradorrepository.Read(usuario.Id);
                    if(atirador == null)
                    {
                        Console.WriteLine("Usuário não encontrado.");
                        return View();
                    }else{
                        HttpContext.Session.SetInt32("Id", (int)atirador.Id); 
                        HttpContext.Session.SetString("Nome", atirador.Nome); 
                        HttpContext.Session.SetString("CPF", atirador.CPF); 
                        HttpContext.Session.SetString("RG", atirador.RG); 
                        HttpContext.Session.SetString("Email", atirador.Email); 
                        HttpContext.Session.SetString("Formacao", atirador.Formacao);
                        HttpContext.Session.SetString("RA", atirador.RA);
                        HttpContext.Session.SetString("Numero", atirador.Numero);
                        HttpContext.Session.SetString("Pelotao", atirador.Pelotao.Nome);
                        
                    }
                }

                return RedirectToAction("Index", "Home");
            }catch{
                return View();

            }   
        } 

        public void Email(string emailDestinatario){

            try
            {
                repository.Email(emailDestinatario);
                
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi hoje");
            }
        }
    }
}