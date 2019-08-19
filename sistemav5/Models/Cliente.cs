using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistemav5.Models
{
    public class Cliente
    {
        [Key]
        [Display(Name = "Código Cliente")]
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public int PedidoId { get; set; }

        public ICollection<Pedido> Pedidos = new List<Pedido>();

        public Cliente() { }

        public Cliente(int idCliente, string nome, DateTime dataNascimento, string email, int telefone, int pedidoId)
        {
            IdCliente = idCliente;
            Nome = nome;
            DataNascimento = dataNascimento;
            Email = email;
            Telefone = telefone;
            PedidoId = pedidoId;
        }
    }
}
