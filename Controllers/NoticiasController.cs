using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using E_Players.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace E_Players.Controllers
{
    public class NoticiasController : Controller
    {
        Noticias ntModel = new Noticias();

        public IActionResult Index()
        {
            ViewBag.Noticias = ntModel.ReadAll();
            return View();
        }

        public IActionResult CadastrarNoticia(IFormCollection form){
            Noticias nt = new Noticias();
            nt.IdNoticia = Int32.Parse( form["IdNoticia"]);
            nt.Titulo = form["Titulo"];
            nt.Texto = form["Texto"];

            //Upload da Imagem
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticias");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                nt.Imagem   = file.FileName;
            }
            else
            {
                nt.Imagem   = "padrao.png";
            }

            //Fim - Upload da Imagem
            ntModel.Create(nt);

            ViewBag.Noticias =  ntModel.ReadAll();
            return LocalRedirect("~/Noticias");

        }

        [Route("Noticias/{id}")]
        public IActionResult ExcluirNoticia(int id){
            ntModel.Delete(id);
            ViewBag.Equipes = ntModel.ReadAll();
            return LocalRedirect("~/Noticias");
        } 
 
    }
}
