using angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace angular.Controllers
{
    public class HomeController : Controller
    {
        angularContext db = new angularContext();
        Pessoa p = new Pessoa();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Nome(string nome, string sobrenome,int idade)
        {
            p.Nome = nome;
            p.Sobrenome = sobrenome;
            p.Idade = idade;
            db.Pessoas.Add(p);
            db.SaveChanges();
            return Json("Registrado ");
        }
        public ActionResult ExibiDados()
        {
            return View(db.Pessoas.ToList());
        }
        public JsonResult Dados(int id)
        {
            var lista = db.Pessoas.Where(x => x.Id == id).ToList();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        public void Editar(int Id, string Nome, string Sobrenome, int Idade)
        {
            var pessoa = db.Pessoas.Find(Id);
            pessoa.Nome = Nome;
            pessoa.Sobrenome = Sobrenome;
            pessoa.Idade = Idade;
            db.SaveChanges();
        }
        public void Deletar(int id)
        {
            var pessoa = db.Pessoas.Find(id);
            db.Pessoas.Remove(pessoa);
            db.SaveChanges();
        }
    }
}