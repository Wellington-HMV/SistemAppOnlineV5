using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistemav5.Models;
using Microsoft.EntityFrameworkCore;

namespace sistemav5.Services
{
    public class ClienteService
    {
        private readonly sistemav5Context _context;
        public ClienteService(sistemav5Context context)
        {
            _context = context;
        }
        public async Task<List<Cliente>> FindClientesAsync()
        {
            return await _context.Cliente.ToListAsync();
        }
    }
}
