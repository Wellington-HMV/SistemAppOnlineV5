﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sistemav5.Models;

namespace sistemav5.Services
{
    public class ProdutoService
    {
        private readonly sistemav5Context _context;
        public ProdutoService(sistemav5Context context)
        {
            _context = context;
        }
        public async Task<List<Produto>> FindProdutosAsync()
        {
            return await _context.Produto.ToListAsync();
        }
    }
}
