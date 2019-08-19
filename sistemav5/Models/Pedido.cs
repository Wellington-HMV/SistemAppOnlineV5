using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace sistemav5.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public int ItensPedidoId { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        private ICollection<ItensPedido> Itens { get; set; } = new List<ItensPedido>();
        //LinkedList<ICollection<ItensPedido>> Itens { get; set; } = new LinkedList<ICollection<ItensPedido>>();

        public Pedido() { }

        public Pedido(int idPedido, int quantidade, Cliente cliente, int produtoId, int clienteId)
        {
            Id = idPedido;
            Quantidade = quantidade;
            Cliente = cliente;
            ItensPedidoId = produtoId;
            ClienteId = clienteId;
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