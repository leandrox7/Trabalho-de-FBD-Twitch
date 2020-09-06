using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Twitch.Models;

namespace Twitch.Controllers
{
    public class CanalstreamersController : Controller
    {
        private readonly Context _context;

        public CanalstreamersController(Context context)
        {
            _context = context;
        }

        // GET: Canalstreamers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Canalstreamer.ToListAsync());
        }

        // GET: Canalstreamers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canalstreamer = await _context.Canalstreamer
                .FirstOrDefaultAsync(m => m.CodUsuario == id);
            if (canalstreamer == null)
            {
                return NotFound();
            }

            return View(canalstreamer);
        }

        // GET: Canalstreamers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Canalstreamers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao,Online,Nome,Senha,CodUsuario")] Canalstreamer canalstreamer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(canalstreamer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(canalstreamer);
        }

        // GET: Canalstreamers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canalstreamer = await _context.Canalstreamer.FindAsync(id);
            if (canalstreamer == null)
            {
                return NotFound();
            }
            return View(canalstreamer);
        }

        // POST: Canalstreamers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Descricao,Online,Nome,Senha,CodUsuario")] Canalstreamer canalstreamer)
        {
            if (id != canalstreamer.CodUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(canalstreamer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CanalstreamerExists(canalstreamer.CodUsuario))
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
            return View(canalstreamer);
        }

        // GET: Canalstreamers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canalstreamer = await _context.Canalstreamer
                .FirstOrDefaultAsync(m => m.CodUsuario == id);
            if (canalstreamer == null)
            {
                return NotFound();
            }

            return View(canalstreamer);
        }

        // POST: Canalstreamers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var canalstreamer = await _context.Canalstreamer.FindAsync(id);
            _context.Canalstreamer.Remove(canalstreamer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CanalstreamerExists(int id)
        {
            return _context.Canalstreamer.Any(e => e.CodUsuario == id);
        }
    }
}
