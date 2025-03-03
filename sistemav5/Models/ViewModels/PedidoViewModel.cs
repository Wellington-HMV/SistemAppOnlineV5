﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistemav5.Models.ViewModels
{
    public class PedidoViewModel
    {
        public Pedido Pedido { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public int ClienteId { get; set; }
        public ICollection<Produto> Produtos { get; set; }
        public int ProdutoId { get; set; }
    }
}
