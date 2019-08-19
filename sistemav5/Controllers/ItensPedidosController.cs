using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistemav5.Models;

namespace sistemav5.Controllers
{
    public class ItensPedidosController : Controller
    {
        private readonly sistemav5Context _context;

        public ItensPedidosController(sistemav5Context context)
        {
            _context = context;
        }

        // GET: ItensPedidos
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItensPedido.Include(obj=>obj.Produtos).ToListAsync());
        }

        // GET: ItensPedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itensPedido = await _context.ItensPedido
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itensPedido == null)
            {
                return NotFound();
            }

            return View(itensPedido);
        }

        // GET: ItensPedidos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItensPedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProdutoId,Quantidade")] ItensPedido itensPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itensPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itensPedido);
        }

        // GET: ItensPedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itensPedido = await _context.ItensPedido.FindAsync(id);
            if (itensPedido == null)
            {
                return NotFound();
            }
            return View(itensPedido);
        }

        // POST: ItensPedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProdutoId,Quantidade")] ItensPedido itensPedido)
        {
            if (id != itensPedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itensPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItensPedidoExists(itensPedido.Id))
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
            return View(itensPedido);
        }

        // GET: ItensPedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itensPedido = await _context.ItensPedido
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itensPedido == null)
            {
                return NotFound();
            }

            return View(itensPedido);
        }

        // POST: ItensPedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itensPedido = await _context.ItensPedido.FindAsync(id);
            _context.ItensPedido.Remove(itensPedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItensPedidoExists(int id)
        {
            return _context.ItensPedido.Any(e => e.Id == id);
        }
    }
}
