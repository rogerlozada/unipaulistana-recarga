using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using recarga.Models;
using recarga.repository;

namespace recarga.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            AtualizarLista();
            return View();
        }


        [HttpPost]
        public IActionResult Index(Models.ModeloDadosDaRecarga modelo)
        {
            var dadosDaRecargaRepository = new DadosDaRecargaRepository();
            dadosDaRecargaRepository.Inserir(modelo);
            AtualizarLista();
            return View();
        }


        void AtualizarLista()
        {
            var dadosDaRecargaRepository = new DadosDaRecargaRepository();
            ViewBag.ListaDeRecargas = dadosDaRecargaRepository.ObterTodos();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
