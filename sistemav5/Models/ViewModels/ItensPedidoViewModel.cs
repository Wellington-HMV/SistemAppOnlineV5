using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistemav5.Models.ViewModels
{
    public class ItensPedidoViewModel
    {
        public ICollection<Produto> Produtos { get; set; }
        public ItensPedido ItensPedido { get; set; }

        List<Produto> ViewList { get; set; } = new List<Produto>();

        public void AddProdutoVM(Produto p,int quantidade)
        {
            ViewList.Add(p);
            p.Quantidade -= quantidade;
        }
    }
}
