using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoParaProjetos.Repositorios;

namespace ProjetoParaProjetos.Controllers
{
    [Route("[controller]")]
    public class ProjetosController : Controller
    {
        private readonly ILogger<ProjetosController> _logger;

        private readonly BancoDadosRepositorio _bancoDados;

        public ProjetosController(ILogger<ProjetosController> logger, BancoDadosRepositorio bancoDados)
        {
            _logger = logger;
            _bancoDados = bancoDados;
        }

    
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("Cadastrar")]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost("CriarT")]
        public IActionResult CriarT(Models.Projeto projeto)
        {
            _bancoDados.AddTarefa(projeto);
            return RedirectToAction("Index");
        }

        [HttpGet("Editar/{id}")]
        public IActionResult Editar(int id)
        {
            var projeto = _bancoDados.GetTarefa(id);
            return View(projeto);
        }

        [HttpPost("Editar/{id}")]
        public IActionResult Editar(Models.Projeto projeto)
        {
            _bancoDados.UpdateTarefa(projeto);
            return RedirectToAction("Index");
        }

        [HttpGet("Deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            var projeto = _bancoDados.GetTarefa(id);
            return View(projeto);
        }

        [HttpPost("Deletar/{id}")]
        public IActionResult Deletar(Models.Projeto projeto)
        {
            _bancoDados.DeleteTarefa(projeto);
            return RedirectToAction("Index");
        }

        [HttpGet("Detalhes/{id}")]
        public IActionResult Detalhes(int id)
        {
            var projeto = _bancoDados.GetTarefa(id);
            return View(projeto);
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var projetos = _bancoDados.GetTarefas();
            return View(projetos);
        }

        









        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}