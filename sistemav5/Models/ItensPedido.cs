using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace sistemav5.Models
{
    public class ItensPedido
    {

        [Display(Name = "Código Lista Itens")]
        public int Id { get; set; }
        public int? ProdutoId { get; set; }
        public int? PedidoId { get; set; }
        public Produto Produto { get; set; }

        public ItensPedido()
        {
        }
    }
}