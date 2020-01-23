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
        [Display(Name = "CodigoCliente")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "DataNascimento")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "NumeroTelefone")]
        [DataType(DataType.PhoneNumber)]
        public int Telefone { get; set; }

        public ICollection<Pedido> Pedidos = new List<Pedido>();
    }
}
