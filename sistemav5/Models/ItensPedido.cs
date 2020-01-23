using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemav5.Models
{
    public class ItensPedido
    {

        [Display(Name = "Código Lista Itens")]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int PedidoId { get; set; }
        [NotMapped]
        public ICollection<Produto> Produtos { get; set; }

        public ItensPedido()
        {
        }
    }
}