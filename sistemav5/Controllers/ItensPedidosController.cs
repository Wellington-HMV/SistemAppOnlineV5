using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistemav5.Models;
using sistemav5.Models.ViewModels;
using sistemav5.Services;
using Microsoft.EntityFrameworkCore;

namespace sistemav5.Controllers
{
    public class ItensPedidosController : Controller
    {
        private readonly sistemav5Context _context;
        private readonly PedidoService _pedidoService;
        private readonly ProdutoService _produtoService;
        private readonly ClienteService _clienteService;
        private readonly ItensPedidoService _itensPedidoService;

        public ItensPedidosController(sistemav5Context context
                                                        , PedidoService pedidoService
                                                        , ProdutoService produtoService
                                                        , ItensPedidoService itensPedidoService
                                                        , ClienteService clienteService)
        {
            _context = context;
            _pedidoService = pedidoService;
            _produtoService = produtoService;
            _clienteService = clienteService;
            _itensPedidoService = itensPedidoService;
        }

        // GET: ItensPedidos
        public async Task<IActionResult> Index()
        {
            var list = await _itensPedidoService.FindItensPedidoAsync();
            return View(list);
        }

        // GET: ItensPedidos/Details/5
        public async Task<IActionResult> Details(int? id, Produto produto)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itensPedido = await _context.ItensPedido.Include(p=>p.Produtos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itensPedido == null)
            {
                return NotFound();
            }
            //var prod = await _produtoService.FindProdutosAsync();
            //var itenId = await _itensPedidoService.FindItensPedidoAsync();
            //var viewModel = new ItensPedidoViewModel { ItensPedido = itenId,Produtos = itensPedido.Produtos};
            return View(itensPedido);
        }

        // GET: ItensPedidos/Create
        public async Task<IActionResult> Create()
        {
            var produtos = await _produtoService.FindProdutosAsync();
            var viewModel = new ItensPedidoViewModel { Produtos = produtos };
            return View(viewModel);
        }

        // POST: ItensPedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItensPedido itensPedido)
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
