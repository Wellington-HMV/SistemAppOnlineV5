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

namespace sistemav5.Controllers
{
    public class PedidosController : Controller
    {
        private readonly sistemav5Context _context;
        private readonly PedidoService _pedidoService;
        private readonly ProdutoService _produtoService;
        private readonly ClienteService _clienteService;
        private readonly ItensPedidoService _itensPedidoService;

        public PedidosController(sistemav5Context context
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

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            var list = await _pedidoService.FindPedidosAsync();
            IList<Pedido> pedidos = list;
            return View(pedidos);
            //return View(await _context.Pedido.ToListAsync());
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidos/Create
        public async Task<IActionResult> Create()
        {
            var produto = await _produtoService.FindProdutosAsync();
            var clientes = await _clienteService.FindClientesAsync();
            var itensPedido = await _itensPedidoService.FindItensPedidoAsync();
            var viewModel = new PedidoViewModel { Clientes = clientes, Produtos = produto };
            return View(viewModel);
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PedidoViewModel pedido)
        {
            if (!ModelState.IsValid)
            {
                var produto = await _produtoService.FindProdutosAsync();
                var clientes = await _clienteService.FindClientesAsync();
                var itensPedido = await _itensPedidoService.FindItensPedidoAsync();
                var viewModel = new PedidoViewModel { Clientes = clientes, Produtos = produto };
                return View(viewModel);
            }
                _context.Add(new Pedido { ClienteId = pedido.ClienteId, ItensPedidoId = pedido.ProdutoId });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.Id))
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
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.Id == id);
        }
    }
}
