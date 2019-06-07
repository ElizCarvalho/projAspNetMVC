using Service.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class PessoaController : Controller
    {

        // GET: Pessoa
        public ActionResult Index()
        {
            ViewBag.Message = "My first view.";
            return View();
        }

        //GET: Pessoa/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //POST: Pessoa/Create
        [HttpPost]
        public ActionResult Create(PessoaViewModel model)
        {
            ModelState.Remove("Codigo");
            if (ModelState.IsValid)
            {
				#region Old
				//List<Pessoa> lista = new List<Pessoa>();

				//if (Session["ListaPessoas"] != null)
				//{
				//    lista.AddRange((List<Pessoa>)Session["ListaPessoas"]);
				//}
				//model.Codigo = lista.Count + 1;

				//lista.Add(model);

				//Session["ListaPessoas"] = lista;



				//return View("List", lista);
				#endregion
				if(model.Captch == "123#$")
				{
					var _service = new PessoaService();

					//Mapeando objeto
					var pessoaEntity = AutoMapper.Mapper.Map<PessoaViewModel, Pessoa>(model);

					_service.Salvar(pessoaEntity);

					return View("List", _service.Listar());
				}
			}
			return View(model);
        }

        //GET: Pessoa/List
        [HttpGet]
        public ActionResult List()
        {
			#region Old
			//if (Session["ListaPessoas"] != null)
			//{
			//    var model = (List<Pessoa>)Session["ListaPessoas"];
			//    return View(model);
			//}
			#endregion
			var _service = new PessoaService();
			return View(_service.Listar());  
        }

		//GET: Pessoa/Details/5
		[HttpGet]
		public ActionResult Details(int id)
		{
			//Recuperar o objeto com o id
			var _service = new PessoaService();
			var model = _service.Obter(id);
			if (model != null)
			{
				return View("Details", model);
			}

			return View(_service.Listar());
		}

        //GET: Pessoa/Edit
        [HttpGet]
        public ActionResult Edit (int id)
        {
			#region Old
			//Recuperar o objeto com o id
			//var model = ((List<Pessoa>)Session["ListaPessoas"]).Where(x => x.Codigo == id).FirstOrDefault();
			//if (model != null)
			//{
			//    //Enviar o objeto encontrada para a view de edição
			//    return View("Create", model);
			//}
			#endregion
			//Recuperar o objeto com o id
			var _service = new PessoaService();
			var entity = _service.Obter(id);
			
			if (entity != null)
			{
				var model = AutoMapper.Mapper.Map<Pessoa, PessoaViewModel>(entity);
				return View("Create", model);
			}

			return View("Create", new PessoaViewModel());
        }

        //POST: Pessoa/Edit/5
        [HttpPost]
        public ActionResult Edit(PessoaViewModel model, int id)
        {
			#region Old
			//var lista = (List<Pessoa>)Session["ListaPessoas"];

			//if (lista != null || lista.Count != 0)
			//{
			//    //Recuperar o objeto com o id
			//    var modelOld = lista.Where(x => x.Codigo == id).FirstOrDefault();
			//    if (modelOld != null)
			//    {
			//        //Atualiza seu registro com o model enviado por parametro
			//        lista[modelOld.Codigo - 1] = model;
			//    }
			//    //Retorna para lista com o registro atualizado
			//    return View("List", lista);
			//}
			//else
			//{
			//    return View("List", new List<Pessoa>());
			//}
			#endregion

			if (ModelState.IsValid)
			{
				var _service = new PessoaService();
				var entity = AutoMapper.Mapper.Map<PessoaViewModel, Pessoa>(model);
				_service.Salvar(entity);
				return View("List", _service.Listar());

			}
			return View(model);
		}

		//POST: Pessoa/Delete/5
		public ActionResult Delete(int id)
        {
			#region Old
			//var lista = (List<Pessoa>)Session["ListaPessoas"];

			//if (lista != null || lista.Count != 0)
			//{
			//    //Recuperar o objeto com o id
			//    var model = lista.Where(x => x.Codigo == id).FirstOrDefault();
			//    if (model != null)
			//    {
			//        //Remove o objeto encontrado
			//        lista.Remove(model);
			//        Session["ListaPessoas"] = lista;

			//        return View("List", lista);
			//    }
			//}  
			//return View("List", new List<Pessoa>());
			#endregion

			var _service = new PessoaService();
			_service.Deletar(id);
			return View("List", _service.Listar());

		}
	}
}