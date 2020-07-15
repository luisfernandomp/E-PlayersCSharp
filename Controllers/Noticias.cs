using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using E_Players.Models;
using Microsoft.AspNetCore.Http;

namespace E_Players.Controllers
{
    public class Noticias : Controller
    {
        Equipe equipeModel = new Equipe();


        public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form){
            Equipe equipe = new Equipe();
            equipe.IdEquipe = Int32.Parse( form["IdEquipe"]);
            equipe.Nome = form["Nome"];
            equipe.Imagem = form["Imagem"];

            equipeModel.Create(equipe);

            ViewBag.Equipes = equipeModel.ReadAll();
            return LocalRedirect("~/Equipe");

        }
    }
}
