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
    public class AssuntoController : Controller
    {
        private readonly Contexto _context;

        public AssuntoController(Contexto context)
        {
            _context = context;
        }

        // GET: Assunto
        public async Task<IActionResult> Index()
        {
            return View(await _context.Assuntos.OrderByDescending(a => a.Id).ToListAsync());
        }

        // GET: Assunto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assunto = await _context.Assuntos
                .SingleOrDefaultAsync(m => m.Id == id);
            if (assunto == null)
            {
                return NotFound();
            }

            return View(assunto);
        }

        // GET: Assunto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assunto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo")] Assunto assunto)
        {
            if (ModelState.IsValid)
            {
                assunto.DataHoraModificacao = DateTime.Now;
                _context.Add(assunto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assunto);
        }

        // GET: Assunto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assunto = await _context.Assuntos.SingleOrDefaultAsync(m => m.Id == id);
            if (assunto == null)
            {
                return NotFound();
            }
            return View(assunto);
        }

        // POST: Assunto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo")] Assunto assunto)
        {
            if (id != assunto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    assunto.DataHoraModificacao = DateTime.Now;
                    _context.Update(assunto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssuntoExists(assunto.Id))
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
            return View(assunto);
        }

        // GET: Assunto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assunto = await _context.Assuntos
                .SingleOrDefaultAsync(m => m.Id == id);
            if (assunto == null)
            {
                return NotFound();
            }

            return View(assunto);
        }

        // POST: Assunto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assunto = await _context.Assuntos.SingleOrDefaultAsync(m => m.Id == id);
            _context.Assuntos.Remove(assunto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssuntoExists(int id)
        {
            return _context.Assuntos.Any(e => e.Id == id);
        }
    }
}
