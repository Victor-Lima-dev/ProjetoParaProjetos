using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoParaProjetos.Models;
using ProjetoParaProjetos.context;

namespace ProjetoParaProjetos.Controllers
{
    public class CasoClinicoesController : Controller
    {
        private readonly AppDbContext _context;

        public CasoClinicoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CasoClinicoes
        public async Task<IActionResult> Index()
        {
              return _context.CasosClinicos != null ? 
                          View(await _context.CasosClinicos.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.CasosClinicos'  is null.");
        }

        // GET: CasoClinicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CasosClinicos == null)
            {
                return NotFound();
            }

            var casoClinico = await _context.CasosClinicos
                .FirstOrDefaultAsync(m => m.CasoClinicoId == id);
            if (casoClinico == null)
            {
                return NotFound();
            }

            return View(casoClinico);
        }

        // GET: CasoClinicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CasoClinicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CasoClinicoId,Caso")] CasoClinico casoClinico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casoClinico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(casoClinico);
        }

        // GET: CasoClinicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CasosClinicos == null)
            {
                return NotFound();
            }

            var casoClinico = await _context.CasosClinicos.FindAsync(id);
            if (casoClinico == null)
            {
                return NotFound();
            }
            return View(casoClinico);
        }

        // POST: CasoClinicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CasoClinicoId,Caso")] CasoClinico casoClinico)
        {
            if (id != casoClinico.CasoClinicoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casoClinico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasoClinicoExists(casoClinico.CasoClinicoId))
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
            return View(casoClinico);
        }

        // GET: CasoClinicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CasosClinicos == null)
            {
                return NotFound();
            }

            var casoClinico = await _context.CasosClinicos
                .FirstOrDefaultAsync(m => m.CasoClinicoId == id);
            if (casoClinico == null)
            {
                return NotFound();
            }

            return View(casoClinico);
        }

        // POST: CasoClinicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CasosClinicos == null)
            {
                return Problem("Entity set 'AppDbContext.CasosClinicos'  is null.");
            }
            var casoClinico = await _context.CasosClinicos.FindAsync(id);
            if (casoClinico != null)
            {
                _context.CasosClinicos.Remove(casoClinico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasoClinicoExists(int id)
        {
          return (_context.CasosClinicos?.Any(e => e.CasoClinicoId == id)).GetValueOrDefault();
        }
    }
}
