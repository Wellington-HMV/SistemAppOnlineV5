﻿using System.Collections.Generic;
using System.Linq;

namespace sistemav5.Models
{
    public class ItensPedido
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Pedido Pedido { get; set; }
        public int Quantidade { get; set; }
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();

        public ItensPedido()
        {
        }

        public ItensPedido(int id, int produtoId, Pedido pedido, int quantidade)
        {
            Id = id;
            ProdutoId = produtoId;
            Pedido = pedido;
            Quantidade = quantidade;
        }
        public void AddProduto(Produto p)
        {
            Produtos.Add(p);
        }
        public void RemoveProduto(Produto p)
        {
            Produtos.Remove(p);
        }
        public string ProdutoIp(int id)
        {
            var produtos = Produtos.Where(p => p.IdProduto == id).Select(p => p.Nome).ToString();
            return produtos;

        }
    }
}