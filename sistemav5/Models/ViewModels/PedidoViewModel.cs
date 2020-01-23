using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistemav5.Models.ViewModels
{
    public class PedidoViewModel
    {

        [Display(Name = "Código Pedido")]
        public int Id { get; set; }
        //public int Quantidade { get; set; }
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public List<ItensPedido> ItensPedido { get; set; }

        public PedidoViewModel()
        {
            this.ItensPedido = new List<ItensPedido>();
        }
    }
}
