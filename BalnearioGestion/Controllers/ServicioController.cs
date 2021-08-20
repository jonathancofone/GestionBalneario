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
    public class ServicioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Servicio
        public async Task<IActionResult> Index(DateTime? BuscarFecha)
        {
            if (BuscarFecha == null)
            {
                var applicationDbContext = _context.ServicioBalnearios.Include(s => s.Cliente);
                return View(await applicationDbContext.ToListAsync());

            }
            else
            {
                ViewData["buscarfecha"] = BuscarFecha;

                var applicationDbContext = _context.ServicioBalnearios.Include(s => s.Cliente)
                                   .Where(s => s.FechaGestion == BuscarFecha);
                return View(await applicationDbContext.ToListAsync());

            }
        }

        // GET: Servicio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioBalneario = await _context.ServicioBalnearios
                .Include(s => s.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicioBalneario == null)
            {
                return NotFound();
            }

            return View(servicioBalneario);
        }

        // GET: Servicio/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "Nombre");
            
            return View();
        }

        // POST: Servicio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaGestion,FechaDesde,FechaHasta,ClienteId,AlquilaCarpa,AlquilaSombrilla,IdAlquila,Valor,FormaDePago")] ServicioBalneario servicioBalneario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicioBalneario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "Nombre", servicioBalneario.ClienteId);
            return View(servicioBalneario);
        }

        // GET: Servicio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioBalneario = await _context.ServicioBalnearios.FindAsync(id);
            if (servicioBalneario == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "Nombre", servicioBalneario.ClienteId);
            return View(servicioBalneario);
        }

        // POST: Servicio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaGestion,FechaDesde,FechaHasta,ClienteId,AlquilaCarpa,AlquilaSombrilla,IdAlquila,Valor,FormaDePago")] ServicioBalneario servicioBalneario)
        {
            if (id != servicioBalneario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioBalneario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioBalnearioExists(servicioBalneario.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "Nombre", servicioBalneario.ClienteId);
            return View(servicioBalneario);
        }

        // GET: Servicio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioBalneario = await _context.ServicioBalnearios
                .Include(s => s.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicioBalneario == null)
            {
                return NotFound();
            }

            return View(servicioBalneario);
        }

        // POST: Servicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicioBalneario = await _context.ServicioBalnearios.FindAsync(id);
            _context.ServicioBalnearios.Remove(servicioBalneario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioBalnearioExists(int id)
        {
            return _context.ServicioBalnearios.Any(e => e.Id == id);
        }
    }
}
