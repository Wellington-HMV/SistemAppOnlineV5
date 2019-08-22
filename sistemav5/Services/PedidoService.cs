using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sistemav5.Models;
using sistemav5.Models.ViewModels;

namespace sistemav5.Services
{
    public class PedidoService
    {
        private readonly sistemav5Context _context;
        public PedidoService(sistemav5Context context)
        {
            _context = context;
        }
        public async Task<List<Pedido>> FindPedidosAsync()
        {
            return await _context.Pedido.Include(cl => cl.Cliente).ToListAsync();
            //return await _context.Pedido.Include(obj=>obj.ItensPedidoId).OrderBy(obj=>obj.Cliente).ToListAsync();
        }
        public async Task insertToItensAsync(Pedido pedido)
        {
            var clienteIdInsert = _context.Pedido.Where(p => p.ClienteId == pedido.ClienteId).FirstOrDefault();
            var produtoIdInsert = _context.Produto.Where(p => p.Id == pedido.ItensPedidoId).FirstOrDefault();

            string[] dados = new string [0];
            dados[0] = clienteIdInsert.ToString();
            dados[1] = produtoIdInsert.ToString();

            _context.Update(pedido);
            await _context.SaveChangesAsync();
        }
    }
}
