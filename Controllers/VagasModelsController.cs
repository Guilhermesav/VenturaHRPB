using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VenturaHRPB.Data;
using VenturaHRPB.Model;

namespace VenturaHRPB.Controllers
{
    public class VagasModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VagasModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VagasModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.VagasModel.ToListAsync());
        }

        // GET: VagasModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vagasModel = await _context.VagasModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vagasModel == null)
            {
                return NotFound();
            }

            return View(vagasModel);
        }

        // GET: VagasModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VagasModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,Competencias,Empresa")] VagasModel vagasModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vagasModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vagasModel);
        }

        // GET: VagasModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vagasModel = await _context.VagasModel.FindAsync(id);
            if (vagasModel == null)
            {
                return NotFound();
            }
            return View(vagasModel);
        }

        // POST: VagasModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,Competencias,Empresa")] VagasModel vagasModel)
        {
            if (id != vagasModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vagasModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VagasModelExists(vagasModel.Id))
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
            return View(vagasModel);
        }

        // GET: VagasModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vagasModel = await _context.VagasModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vagasModel == null)
            {
                return NotFound();
            }

            return View(vagasModel);
        }

        // POST: VagasModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vagasModel = await _context.VagasModel.FindAsync(id);
            _context.VagasModel.Remove(vagasModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VagasModelExists(int id)
        {
            return _context.VagasModel.Any(e => e.Id == id);
        }
    }
}
