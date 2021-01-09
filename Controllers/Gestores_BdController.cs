using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using netcore_api_example.Context;

namespace netcore_api_example.Models
{
    public class Gestores_BdController : Controller
    {
        private readonly AppDbContext _context;
        /**
         * De esta clase se pueden crear los tipos de vistas diferentes.
         * Primero se crea el controlador a partir del modelo, 
         * despues se crear las vistas: En este caso este 
         * es un controlador MVC, no API, por eso aqui no funciona
        **/
        public Gestores_BdController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Gestores_Bd
        public async Task<IActionResult> Index()
        {
            return View(await _context.gestores_bd.ToListAsync());
        }

        // GET: Gestores_Bd/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestores_Bd = await _context.gestores_bd
                .FirstOrDefaultAsync(m => m.id == id);
            if (gestores_Bd == null)
            {
                return NotFound();
            }

            return View(gestores_Bd);
        }

        // GET: Gestores_Bd/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gestores_Bd/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre,lanzamiento,desarrollador,owner")] Gestores_Bd gestores_Bd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gestores_Bd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gestores_Bd);
        }

        // GET: Gestores_Bd/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestores_Bd = await _context.gestores_bd.FindAsync(id);
            if (gestores_Bd == null)
            {
                return NotFound();
            }
            return View(gestores_Bd);
        }

        // POST: Gestores_Bd/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,lanzamiento,desarrollador,owner")] Gestores_Bd gestores_Bd)
        {
            if (id != gestores_Bd.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gestores_Bd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Gestores_BdExists(gestores_Bd.id))
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
            return View(gestores_Bd);
        }

        // GET: Gestores_Bd/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestores_Bd = await _context.gestores_bd
                .FirstOrDefaultAsync(m => m.id == id);
            if (gestores_Bd == null)
            {
                return NotFound();
            }

            return View(gestores_Bd);
        }

        // POST: Gestores_Bd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gestores_Bd = await _context.gestores_bd.FindAsync(id);
            _context.gestores_bd.Remove(gestores_Bd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Gestores_BdExists(int id)
        {
            return _context.gestores_bd.Any(e => e.id == id);
        }
    }
}
