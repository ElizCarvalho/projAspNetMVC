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
        public ActionResult Create(PessoaModels model)
        {
            ModelState.Remove("Codigo");
            if (ModelState.IsValid)
            {
                List<PessoaModels> lista = new List<PessoaModels>();

                if (Session["ListaPessoas"] != null)
                {
                    lista.AddRange((List<PessoaModels>)Session["ListaPessoas"]);
                }
                model.Codigo = lista.Count + 1;

                lista.Add(model);

                Session["ListaPessoas"] = lista;

                return View("List", lista);
            }
            return View(model);
        }

        //GET: Pessoa/List
        [HttpGet]
        public ActionResult List()
        {
            if (Session["ListaPessoas"] != null)
            {
                var model = (List<PessoaModels>)Session["ListaPessoas"];
                return View(model);
            }
            return View(new List<PessoaModels>());  
        }

        //GET: Pessoa/Edit
        [HttpGet]
        public ActionResult Edit (int id)
        {
            //Recuperar o objeto com o id
            var model = ((List<PessoaModels>)Session["ListaPessoas"]).Where(x => x.Codigo == id).FirstOrDefault();
            if (model != null)
            {
                //Enviar o objeto encontrada para a view de edição
                return View("Create", model);
            }

            return View("Create", new PessoaModels());
        }

        //POST: Pessoa/Edit/5
        [HttpPost]
        public ActionResult Edit(PessoaModels model, int id)
        {
            var lista = (List<PessoaModels>)Session["ListaPessoas"];

            if (lista != null || lista.Count != 0)
            {
                //Recuperar o objeto com o id
                var modelOld = lista.Where(x => x.Codigo == id).FirstOrDefault();
                if (modelOld != null)
                {
                    //Atualiza seu registro com o model enviado por parametro
                    lista[modelOld.Codigo - 1] = model;
                }
                //Retorna para lista com o registro atualizado
                return View("List", lista);
            }
            else
            {
                return View("List", new List<PessoaModels>());
            }
        }

        //POST: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            var lista = (List<PessoaModels>)Session["ListaPessoas"];

            if (lista != null || lista.Count != 0)
            {
                //Recuperar o objeto com o id
                var model = lista.Where(x => x.Codigo == id).FirstOrDefault();
                if (model != null)
                {
                    //Remove o objeto encontrado
                    lista.Remove(model);
                    Session["ListaPessoas"] = lista;

                    return View("List", lista);
                }
            }  
            return View("List", new List<PessoaModels>());
        }
    }
}