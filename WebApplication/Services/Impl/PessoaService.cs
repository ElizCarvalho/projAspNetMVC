using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;

namespace Service.Impl
{
	public class PessoaService
	{
		//CRUD

		//Salvar
		public void Salvar(Pessoa pessoa)
		{
			using(var db = new MyContext())
			{
				if (pessoa.Codigo > 0) //se não for um novo registro
				{
					db.Pessoa.Attach(pessoa);
					db.Entry(pessoa).State = System.Data.Entity.EntityState.Modified;
				}
				else
					db.Pessoa.Add(pessoa); //sendo um registro novo

				db.SaveChanges();
			}
		}
		
		//Obter
		public Pessoa Obter(int codigo)
		{
			using(var db = new MyContext())
			{
				return db.Pessoa.Find(codigo);
			}
		}

		//Listar todos
		public List<Pessoa> Listar()
		{
			using(var db = new MyContext())
			{
				return db.Pessoa.ToList();
			}
		}

		//Delete
		public void Deletar(int codigo)
		{
			using(var db = new MyContext())
			{
				var p = new Pessoa() { Codigo = codigo };
				db.Pessoa.Attach(p);
				db.Pessoa.Remove(p);
				db.SaveChanges();
			}
		}
	}
}
