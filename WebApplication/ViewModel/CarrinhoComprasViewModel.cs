using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Model
{
	public class CarrinhoComprasViewModel
	{
		public List<Produto> Produtos { get; set; }
		public decimal ValorTotal { get; set; }
		public string Mensagem { get; set; }
	}
}