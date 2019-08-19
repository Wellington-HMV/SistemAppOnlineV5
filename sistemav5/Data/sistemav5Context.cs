using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace sistemav5.Models
{
    public class sistemav5Context : DbContext
    {
        public sistemav5Context (DbContextOptions<sistemav5Context> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ItensPedido> ItensPedido { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
    }
}
