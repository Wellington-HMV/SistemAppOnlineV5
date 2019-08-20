using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace sistemav5.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        //public int Quantidade { get; set; }
        public int ItensPedidoId { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public ItensPedido ItensPedido { get; set; }

        private ICollection<ItensPedido> Itens { get; set; } = new List<ItensPedido>();
        //LinkedList<ICollection<ItensPedido>> Itens { get; set; } = new LinkedList<ICollection<ItensPedido>>();

        public Pedido() { }

        public Pedido(int id, int itensPedidoId, int clienteId, Cliente cliente, ItensPedido itensPedido)
        {
            Id = id;
            ItensPedidoId = itensPedidoId;
            ClienteId = clienteId;
            Cliente = cliente;
            ItensPedido = itensPedido;
        }

        public void AddItensPedido(ItensPedido iP)
        {
            Itens.Add(iP);
        }
        public void RemoveItensPedido(ItensPedido iP)
        {
            Itens.Remove(iP);
        }
    }
}