using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Odonto.Core.Models;
using Odonto.Data.EntityFramework;

namespace Odonto.WebApp.Controllers
{
    public class QuestaoController : Controller
    {
        private readonly Contexto _context;

        public QuestaoController(Contexto context)
        {
            _context = context;
        }

        // GET: Questao
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Questoes.Include(q => q.Exercicio).OrderByDescending(l => l.Id);
            return View(await contexto.ToListAsync());
        }

        // GET: Questao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questao = await _context.Questoes
                .Include(q => q.Exercicio)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (questao == null)
            {
                return NotFound();
            }

            return View(questao);
        }

        // GET: Questao/Create
        public IActionResult Create()
        {
            var exercicios = from t in _context.Exercicios
                          select t;

            ViewData["Exercicios"] = new SelectList(exercicios.ToList(), "Id", "Descricao");
            return View();
        }

        // POST: Questao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, TextoPergunta, Resposta, HtmlPergunta, ExercicioId")] Questao questao)
        {
            if (ModelState.IsValid)
            {
                questao.DataHoraModificacao = DateTime.Now;
                _context.Add(questao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var exercicios = from t in _context.Exercicios
                select t;

            ViewData["Exercicios"] = new SelectList(exercicios.ToList(), "Id", "Descricao");
            return View(questao);
        }

        // GET: Questao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questao = await _context.Questoes.Include(q => q.Exercicio).SingleOrDefaultAsync(m => m.Id == id);
            if (questao == null)
            {
                return NotFound();
            }

            var exercicios = from t in _context.Exercicios
                select t;

            ViewData["Exercicios"] = new SelectList(exercicios.ToList(), "Id", "Descricao");

            return View(questao);
        }

        // POST: Questao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, TextoPergunta, Resposta, HtmlPergunta, ExercicioId")] Questao questao)
        {
            if (id != questao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    questao.DataHoraModificacao = DateTime.Now;
                    _context.Update(questao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestaoExists(questao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            var exercicios = from t in _context.Exercicios
                select t;

            ViewData["Exercicios"] = new SelectList(exercicios.ToList(), "Id", "Descricao");
            return View(questao);
        }

        // GET: Questao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questao = await _context.Questoes
                .Include(q => q.Exercicio)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (questao == null)
            {
                return NotFound();
            }

            return View(questao);
        }

        // POST: Questao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questao = await _context.Questoes.Include(q => q.Exercicio).SingleOrDefaultAsync(m => m.Id == id);
            _context.Questoes.Remove(questao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestaoExists(int id)
        {
            return _context.Questoes.Any(e => e.Id == id);
        }
    }
}
