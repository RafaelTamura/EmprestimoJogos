using EmprestimoJogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmprestimoJogos.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private EmprestimoJogosEntities db = new EmprestimoJogosEntities();

        public ActionResult Index()
        {
            IList<Emprestimo> emprestimos = db.Emprestimos.ToList();

            foreach (var emprestimo in emprestimos)
            {
                Amigo amigo = db.Amigos.Find(emprestimo.IdAmigo);
                if (amigo != null)
                {
                    emprestimos[emprestimos.IndexOf(emprestimo)].Amigo = amigo;
                }

                Jogo jogo = db.Jogos.Find(emprestimo.IdJogo);
                if (jogo != null)
                {
                    emprestimos[emprestimos.IndexOf(emprestimo)].Jogo = jogo;
                }
            }

            return View(emprestimos);
        }
    }
}