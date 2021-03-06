using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }

        public IActionResult Login()
        {
            
            ViewData["mensagem"] = "Bem vindo ai sistema de controle de emprestimo de livros!";
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {           
            if(Autenticacao.verificaLoginSenha(usuario.Login, usuario.Senha, this))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Erro"] = "Senha ou Login inválido!";
                return View();
            }
        }
        public IActionResult Logout()
        {           
            Autenticacao.Logout(this);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
