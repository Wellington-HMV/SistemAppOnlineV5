using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sistemav5.Models;

namespace sistemav5.Services
{
    public class PedidoService
    {
        private readonly sistemav5Context _context;
        public PedidoService(sistemav5Context context)
        {
            _context = context;
        }
        public async Task <List<Pedido>> FindPedidosAsync()
        {
            return await _context.Pedido.Include(cl => cl.Cliente).ToListAsync();
            //return await _context.Pedido.Include(obj=>obj.ItensPedidoId).OrderBy(obj=>obj.Cliente).ToListAsync();
        }
    }
}
