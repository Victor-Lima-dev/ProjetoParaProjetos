using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoParaProjetos.Interfaces;
using ProjetoParaProjetos.Models;

namespace ProjetoParaProjetos.Controllers
{
    [Route("[controller]")]
    public class TarefasController : Controller
    {
        private readonly IBancoDados _bancoDados;
        private readonly ILogger<TarefasController> _logger;

        public TarefasController(ILogger<TarefasController> logger, IBancoDados bancoDados)
        {
            _logger = logger;
            _bancoDados = bancoDados;
        }


        [HttpGet("Index")]
        public IActionResult Index()
        {
            var listaTarefas = _bancoDados.GetTarefas();


            return View(listaTarefas);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(Models.Tarefa tarefa)
        {
            
                _bancoDados.AddTarefa(tarefa);
                return RedirectToAction("Index");
            
        }

        [HttpGet("Edit/{id}")]

        public IActionResult Edit(int id)
        {
            var tarefa = _bancoDados.GetTarefa(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return View(tarefa);
        }

        [HttpPost("Edit/{id}")]
        public IActionResult Edit(Tarefa tarefa)
        {
            
            _bancoDados.UpdateTarefa(tarefa);

            return RedirectToAction("Index");
        }           

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var tarefa = _bancoDados.GetTarefa(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return View(tarefa);
        }

        [HttpPost("Delete/{id}")]
        public IActionResult Delete(Tarefa tarefa)
        {
            _bancoDados.DeleteTarefa(tarefa);

            return RedirectToAction("Index");
        }

        [HttpGet("Details/{id}")]
        public IActionResult Details(int id)
        {
            var tarefa = _bancoDados.GetTarefa(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return View(tarefa);
        }







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}