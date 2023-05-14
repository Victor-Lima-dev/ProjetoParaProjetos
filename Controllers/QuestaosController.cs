using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoParaProjetos.Models;
using ProjetoParaProjetos.context;
using ProjetoParaProjetos.Models.ViewModels;

namespace ProjetoParaProjetos.Controllers
{
    public class QuestaosController : Controller
    {
        private readonly AppDbContext _context;

        public QuestaosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Questaos
        public async Task<IActionResult> Index()
        {



            var alternativas = _context.Alternativas.ToList();


            return _context.Questoes != null ?
                        View(await _context.Questoes.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.Questoes'  is null.");
        }

        // GET: Questaos/Details/5
        public IActionResult Details(int id)
        {
            // Aqui você precisa obter os dados da questão e suas alternativas com base no ID fornecido
            // Por exemplo, você pode usar um serviço ou um repositório para buscar os dados no banco de dados

            Questao questao = _context.Questoes.Find(id);
            List<Alternativa> alternativas = _context.Alternativas.Where(a => a.QuestaoId == id).ToList();

            Alternativa alternativa1 = alternativas.Count >= 1 ? alternativas[0] : null;
            Alternativa alternativa2 = alternativas.Count >= 2 ? alternativas[1] : null;
            Alternativa alternativa3 = alternativas.Count >= 3 ? alternativas[2] : null;


            // Crie uma instância do ViewModel e preencha com os dados obtidos
            QuestaoAlternativaViewlModel viewModel = new QuestaoAlternativaViewlModel
            {
                Questao = questao,
                Alternativa1 = alternativa1,
                Alternativa2 = alternativa2,
                Alternativa3 = alternativa3
            };

            return View(viewModel);
        }

        // GET: Questaos/Create
        public IActionResult Create()
        {

            var listaCasosClinicos = _context.CasosClinicos.ToList();

            ViewData["ListaCasosClinicos"] = listaCasosClinicos;


            return View();


        }

        // POST: Questaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(QuestaoAlternativaViewlModel viewModel)
        {

            Questao questao = viewModel.Questao;
            questao.CasoClinicoId = viewModel.Questao.CasoClinicoId;
            questao.Alternativas = new List<Alternativa>
            {
                viewModel.Alternativa1,
                viewModel.Alternativa2,
                viewModel.Alternativa3
            };

            _context.Questoes.Add(questao);
            _context.SaveChanges();

            // Faça o processamento adicional necessário, como salvar a questão no banco de dados

            return RedirectToAction("Create"); // Redirecionar para a página de listagem de questões
        }



        // GET: Questaos/Edit/5
        // GET: Questao/Edit/5
        public IActionResult Edit(int id)
        {
            // Aqui você pode recuperar a questão e suas alternativas do banco de dados com base no ID fornecido
            // Lógica para recuperar a questão do banco de dados
            Questao questao = _context.Questoes.Find(id);
            // Lógica para recuperar as alternativas do banco de dados
            List<Alternativa> alternativas = _context.Alternativas.Where(a => a.QuestaoId == id).ToList();

            // Certifique-se de tratar os casos em que a questão ou as alternativas não foram encontradas
            if (questao == null || alternativas == null)
            {
                return NotFound();
            }

            QuestaoAlternativaViewlModel viewModel = new QuestaoAlternativaViewlModel
            {
                Questao = questao,
                Alternativa1 = alternativas.Count >= 1 ? alternativas[0] : new Alternativa(),
                Alternativa2 = alternativas.Count >= 2 ? alternativas[1] : new Alternativa(),
                Alternativa3 = alternativas.Count >= 3 ? alternativas[2] : new Alternativa()
            };

            return View(viewModel);
        }

        // POST: Questao/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, QuestaoAlternativaViewlModel viewModel)
        {
            if (id != viewModel.Questao.QuestaoId)
            {
                return NotFound();
            }

            // find the question and its alternatives in the database based on the ID provided
            // Lógica para recuperar a questão do banco de dados
            Questao questao = _context.Questoes.Find(id);
            // Lógica para recuperar as alternativas do banco de dados
            List<Alternativa> alternativas = _context.Alternativas.Where(a => a.QuestaoId == id).ToList();

            //atualizar com as que vieram da view model
            questao.Enunciado = viewModel.Questao.Enunciado;
            questao.RespostaCorreta = viewModel.Questao.RespostaCorreta;

            alternativas[0].Texto = viewModel.Alternativa1.Texto;
            alternativas[1].Texto = viewModel.Alternativa2.Texto;
            alternativas[2].Texto = viewModel.Alternativa3.Texto;





            // atribuir as alternativas atualizadas na questao
            questao.Alternativas = alternativas;

            // atualizar a questao no banco de dados

            _context.Questoes.Update(questao);

            _context.SaveChanges();


            return RedirectToAction("Index"); // Redirecionar para a página de listagem de questões



        }

        // GET: Questaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Questoes == null)
            {
                return NotFound();
            }

            Questao questao = _context.Questoes.Find(id);
            List<Alternativa> alternativas = _context.Alternativas.Where(a => a.QuestaoId == id).ToList();

            Alternativa alternativa1 = alternativas.Count >= 1 ? alternativas[0] : null;
            Alternativa alternativa2 = alternativas.Count >= 2 ? alternativas[1] : null;
            Alternativa alternativa3 = alternativas.Count >= 3 ? alternativas[2] : null;

            QuestaoAlternativaViewlModel viewModel = new QuestaoAlternativaViewlModel
            {
                Questao = questao,
                Alternativa1 = alternativas.Count >= 1 ? alternativas[0] : new Alternativa(),
                Alternativa2 = alternativas.Count >= 2 ? alternativas[1] : new Alternativa(),
                Alternativa3 = alternativas.Count >= 3 ? alternativas[2] : new Alternativa()
            };

            return View(viewModel);
        }

        // POST: Questaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Questoes == null)
            {
                return Problem("Entity set 'AppDbContext.Questoes'  is null.");
            }
            var questao = await _context.Questoes.FindAsync(id);
            if (questao != null)
            {
                _context.Questoes.Remove(questao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestaoExists(int id)
        {
            return (_context.Questoes?.Any(e => e.QuestaoId == id)).GetValueOrDefault();
        }



        // GET: Questaos/Quiz/5
        [HttpGet("Quiz/{id:int}")]
        public IActionResult Quiz(int id)
        {
            // Obtenha a questão com base no ID fornecido
            Questao questao = _context.Questoes.Find(id);

            // Obtenha as alternativas associadas à questão
            List<Alternativa> alternativas = _context.Alternativas.Where(a => a.QuestaoId == id).ToList();

            var alternativaCorreta = questao.RespostaCorreta;

            Alternativa respostaCorreta = new Alternativa
            {
                Texto = alternativaCorreta
            };

            alternativas.Add(respostaCorreta);

            // Embaralhe as alternativas aleatoriamente
            Random random = new Random();
            List<Alternativa> alternativasEmbaralhadas = alternativas.OrderBy(a => random.Next()).ToList();


            var encontrarCaso = _context.CasosClinicos.Find(questao.CasoClinicoId);

            string casoClinico = encontrarCaso.Caso;



            // Crie um ViewModel para passar os dados para a view
            QuizViewModel viewModel = new QuizViewModel
            {
                Questao = questao,
                Alternativas = alternativasEmbaralhadas,
                CasoClinico = casoClinico
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SubmitQuiz(int questaoId, string respostaSelecionada)
        {
            // Obtenha a questão com base no ID fornecido
            Questao questao = _context.Questoes.Find(questaoId);

            // Verifique se a resposta selecionada pelo usuário está correta
            bool respostaCorreta = (respostaSelecionada == questao.RespostaCorreta);

            // Armazene a informação sobre a resposta correta na TempData
            TempData["RespostaCorreta"] = respostaCorreta;

            // Redirecione para a view "Quiz" com o ID da questão
            return RedirectToAction("Quiz", new { id = questaoId });
        }


        [HttpGet("QuizLista")]
        public IActionResult QuizLista(int id)
        {
            // Obtenha o caso clínico com base no ID fornecido
            CasoClinico casoClinico = _context.CasosClinicos.Find(id);

            if (casoClinico == null)
            {
                return NotFound();
            }

            // Obtenha as questões associadas ao caso clínico
            List<Questao> questoes = _context.Questoes.Where(q => q.CasoClinicoId == id).ToList();

            // Crie uma lista de objetos QuizViewModel para cada questão
            List<QuizViewModel> quizViewModels = new List<QuizViewModel>();
            foreach (Questao questao in questoes)
            {
                var pegarAlternativaCorreta = questao.RespostaCorreta;

                Alternativa respostaCorreta = new Alternativa
                {
                    Texto = pegarAlternativaCorreta
                };




                // Obtenha as alternativas associadas à questão
                List<Alternativa> alternativas = _context.Alternativas.Where(a => a.QuestaoId == questao.QuestaoId).ToList();

                alternativas.Add(respostaCorreta);

                // Embaralhe as alternativas aleatoriamente
                Random random = new Random();
                List<Alternativa> alternativasEmbaralhadas = alternativas.OrderBy(a => random.Next()).ToList();

                // Crie um objeto QuizViewModel para a questão atual
                QuizViewModel viewModel = new QuizViewModel
                {
                    Questao = questao,
                    Alternativas = alternativasEmbaralhadas,
                    CasoClinico = casoClinico.Caso
                };

                // Adicione o objeto QuizViewModel à lista
                quizViewModels.Add(viewModel);
            }

            return View(quizViewModels);
        }

        [HttpPost]
        public IActionResult SubmitQuizLista(int questaoId, string respostaSelecionada)
        {
            // Obtenha a questão com base no ID fornecido
            Questao questao = _context.Questoes.Find(questaoId);

            //encontrar o caso clinico
            var encontrarCaso = _context.CasosClinicos.Find(questao.CasoClinicoId);

            var idCaso = encontrarCaso.CasoClinicoId;

            // Verifique se a resposta selecionada pelo usuário está correta
            bool respostaCorreta = (respostaSelecionada == questao.RespostaCorreta);

            // Armazene a informação sobre a resposta correta na TempData
            TempData["RespostaCorreta"] = respostaCorreta;

            // Redirecione para a view "Quiz" com o ID da questão
            return RedirectToAction("QuizLista", new { id = idCaso });
        }




    }
}
