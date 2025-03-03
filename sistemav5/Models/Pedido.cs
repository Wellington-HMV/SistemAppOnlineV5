﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace sistemav5.Models
{
    public class Pedido
    {
        [Key]
        [Display(Name ="Código Pedido")]
        public int Id { get; set; }
        //public int Quantidade { get; set; }
        [Display(Name ="Código Cliente")]
        public int ClienteId { get; set; }
        public int ItensPedidoId { get; set; }
        public Cliente Cliente { get; set; }

        public ICollection<ItensPedido> ItensPedidos { get; set; } = new List<ItensPedido>();

        public Pedido() { }
    }
}