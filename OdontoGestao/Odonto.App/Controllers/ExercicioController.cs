using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Odonto.Core.Models;
using Odonto.Data.EntityFramework;

namespace Odonto.app.Controllers
{
    public class ExercicioController : Controller
    {
        private readonly Contexto _context;

        public ExercicioController(Contexto context)
        {
            _context = context;
        }

        // GET: Exercicio
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Exercicios.Include(l => l.Questoes).OrderByDescending(l => l.Id);
            return View(await contexto.ToListAsync());
        }

        // GET: Exercicio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercicio = await _context.Exercicios
                .Include(l => l.Questoes)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (exercicio == null)
            {
                return NotFound();
            }

            return View(exercicio);
        }

        // GET: Exercicio/Create
        public IActionResult Create()
        {
            /*var questoes = from t in _context.Questoes
                          where !_context.Questoes.Any(m => m.ExercicioId == t.Id)
                          select t;

            ViewData["Questoes"] = new SelectList(topicos.ToList(), "Id", "TextoPergunta");*/
            return View();
        }

        // POST: Exercicio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] Exercicio exercicio)
        {
            if (ModelState.IsValid)
            {
                exercicio.DataHoraModificacao = DateTime.Now;
                _context.Add(exercicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            /*var questoes = from t in _context.Questoes
                            where !_context.Questoes.Any(m => m.ExercicioId == t.Id)
                            select t;

                        ViewData["Questoes"] = new SelectList(topicos.ToList(), "Id", "TextoPergunta");*/

            return View(exercicio);
        }

        // GET: Exercicio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercicio = await _context.Exercicios.SingleOrDefaultAsync(m => m.Id == id);
            if (exercicio == null)
            {
                return NotFound();
            }

            /*var questoes = from t in _context.Questoes
                where !_context.Questoes.Any(m => m.ExercicioId == t.Id)
                select t;

            ViewData["Questoes"] = new SelectList(topicos.ToList(), "Id", "TextoPergunta");*/

            return View(exercicio);
        }

        // POST: Exercicio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] Exercicio exercicio)
        {
            if (id != exercicio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    exercicio.DataHoraModificacao = DateTime.Now;
                    _context.Update(exercicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExercicioExists(exercicio.Id))
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

            /*var questoes = from t in _context.Questoes
              where !_context.Questoes.Any(m => m.ExercicioId == t.Id)
              select t;

                ViewData["Questoes"] = new SelectList(topicos.ToList(), "Id", "TextoPergunta");*/

            return View(exercicio);
        }

        // GET: Exercicio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercicio = await _context.Exercicios
                .Include(l => l.Questoes)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (exercicio == null)
            {
                return NotFound();
            }

            return View(exercicio);
        }

        // POST: Exercicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exercicio = await _context.Exercicios.SingleOrDefaultAsync(m => m.Id == id);
            _context.Exercicios.Remove(exercicio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExercicioExists(int id)
        {
            return _context.Exercicios.Any(e => e.Id == id);
        }
    }
}
