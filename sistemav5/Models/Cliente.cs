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
        [Display(Name = "Código do Cliente")]
        public int Id { get; set; }
        public string Nome { get; set; }
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public int Telefone { get; set; }

        public ICollection<Pedido> Pedidos = new List<Pedido>();
    }
}
