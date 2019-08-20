using System.ComponentModel.DataAnnotations;

namespace sistemav5.Models
{
    public class Produto
    {
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public Produto() { }

        public Produto(int idProduto, string nome, double preco, int quantidade)
        {
            Id = idProduto;
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }
    }
}