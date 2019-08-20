using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sistemav5.Models;

namespace sistemav5.Services
{
    public class ItensPedidoService
    {
        private readonly sistemav5Context _context;
        public ItensPedidoService (sistemav5Context context)
        {
            _context = context;
        }
        public async Task<List<ItensPedido>> FindItensPedidoAsync()
        {
            return await _context.ItensPedido.Include(obj=>obj.Produtos).ToListAsync();
        }
        
    }
}
