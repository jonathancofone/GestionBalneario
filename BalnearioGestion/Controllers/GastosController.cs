using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BalnearioGestion.Data;
using BalnearioGestion.Models;

namespace BalnearioGestion.Controllers
{
    public class GastosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GastosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gastos
        public async Task<IActionResult> Index(DateTime? BuscarFecha)
        {
            if (BuscarFecha == null)
            {
                
                return View(await _context.Gastos.ToListAsync());

            }
            else
            {
                ViewData["buscarfecha"] = BuscarFecha;

                var applicationDbContext = _context.Gastos.Where(s => s.FechaGestion == BuscarFecha);
                return View(await applicationDbContext.ToListAsync());

            }
            
        }

        // GET: Gastos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gastos = await _context.Gastos
                .FirstOrDefaultAsync(m => m.IdGastos == id);
            if (gastos == null)
            {
                return NotFound();
            }

            return View(gastos);
        }

        // GET: Gastos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gastos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGastos,FechaGestion,Valor,Observacion")] Gastos gastos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gastos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gastos);
        }

        // GET: Gastos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gastos = await _context.Gastos.FindAsync(id);
            if (gastos == null)
            {
                return NotFound();
            }
            return View(gastos);
        }

        // POST: Gastos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGastos,FechaGestion,Valor,Observacion")] Gastos gastos)
        {
            if (id != gastos.IdGastos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gastos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GastosExists(gastos.IdGastos))
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
            return View(gastos);
        }

        // GET: Gastos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gastos = await _context.Gastos
                .FirstOrDefaultAsync(m => m.IdGastos == id);
            if (gastos == null)
            {
                return NotFound();
            }

            return View(gastos);
        }

        // POST: Gastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gastos = await _context.Gastos.FindAsync(id);
            _context.Gastos.Remove(gastos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GastosExists(int id)
        {
            return _context.Gastos.Any(e => e.IdGastos == id);
        }
    }
}
