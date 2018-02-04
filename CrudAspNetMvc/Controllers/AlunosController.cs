using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrudAspNetMvc.Models;

namespace CrudAspNetMvc.Controllers
{
    public class AlunosController : Controller
    {
        private EscolaContext db = new EscolaContext();

        // GET: Alunos
        /*public ActionResult Index(string busca = null)
        {
            if (busca != null)
                return View(db.Alunos.Where(a => a.OPM.ToUpper().Contains(busca.ToUpper())).ToList());
            return View(db.Alunos.ToList());
        }
        */

        // GET: Cia
        public ActionResult Index(string buscaOPM = null)
        {
            if (buscaOPM != null)
                return View(db.Alunos.Where(a => a.OPM.ToUpper().Contains(buscaOPM.ToUpper())).OrderBy(keySelector: a => a.RE).ToList());
            return View(db.Alunos.ToList());
        }

        // GET: Alunos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: Alunos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RE,PostoGrad,PostoGradCod,Nome,NomeGuerra,OPM,SitFuncional,Nascimento,Admissao,Sat,Telefone1,Telefone2,Obs,Foto")] Aluno aluno, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                aluno.Nome = aluno.Nome.ToUpper();
                aluno.NomeGuerra = aluno.NomeGuerra.ToUpper();
                aluno.PostoGrad = aluno.PostoGrad.ToUpper();
                aluno.OPM = aluno.OPM.ToUpper();
                if (aluno.SitFuncional != null)
                {
                    aluno.SitFuncional = aluno.SitFuncional.ToUpper();
                }

                switch (aluno.PostoGrad.ToUpper())
                {
                    case "CEL PM":
                        aluno.PostoGradCod = 1;
                        break;

                    case "TEN CEL PM":
                        aluno.PostoGradCod = 2;
                        break;
                    case "MAJ PM":
                        aluno.PostoGradCod = 3;
                        break;
                    case "CAP PM":
                        aluno.PostoGradCod = 4;
                        break;
                    case "1º TEN PM":
                        aluno.PostoGradCod = 5;
                        break;
                    case "2º TEN PM":
                        aluno.PostoGradCod = 6;
                        break;
                    case "ASP PM":
                        aluno.PostoGradCod = 7;
                        break;
                    case "SUB TEN PM":
                        aluno.PostoGradCod = 8;
                        break;
                    case "1ª SGT PM":
                        aluno.PostoGradCod = 9;
                        break;
                    case "2ª SGT PM":
                        aluno.PostoGradCod = 10;
                        break;
                    case "3ª SGT PM":
                        aluno.PostoGradCod = 11;
                        break;
                    case "CB PM":
                        aluno.PostoGradCod = 12;
                        break;
                    case "SD PM":
                        aluno.PostoGradCod = 13;
                        break;
                    case "SD 2ª CL PM":
                        aluno.PostoGradCod = 14;
                        break;

                    default:
                        aluno.PostoGradCod = 15;
                        break;
                }
                db.Alunos.Add(aluno);
                db.SaveChanges();

                if (file != null)
                {
                    String[] strName = file.FileName.Split('.');
                    String strExt = strName[strName.Count() - 1];
                    string pathSave = String.Format("{0}{1}.{2}", Server.MapPath("~/fotos/"), aluno.RE, strExt);
                    String pathBase = String.Format("/fotos/{0}.{1}", aluno.RE, strExt);
                    file.SaveAs(pathSave);
                    aluno.Foto = pathBase;
                    db.SaveChanges();
                }
                    return RedirectToAction("Index");
            }

            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RE,PostoGrad,PostoGradCod,Nome,NomeGuerra,OPM,SitFuncional,Nascimento,Admissao,Sat,Telefone1,Telefone2,Obs,Foto")] Aluno aluno, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                aluno.Nome = aluno.Nome.ToUpper();
                aluno.NomeGuerra = aluno.NomeGuerra.ToUpper();
                aluno.PostoGrad = aluno.PostoGrad.ToUpper();
                aluno.OPM = aluno.OPM.ToUpper();
                if (aluno.SitFuncional != null)
                {
                    aluno.SitFuncional = aluno.SitFuncional.ToUpper();
                }

                switch (aluno.PostoGrad.ToUpper())
                {
                    case "CEL PM":
                        aluno.PostoGradCod = 1;
                        break;

                    case "TEN CEL PM":
                        aluno.PostoGradCod = 2;
                        break;
                    case "MAJ PM":
                        aluno.PostoGradCod = 3;
                        break;
                    case "CAP PM":
                        aluno.PostoGradCod = 4;
                        break;
                    case "1º TEN PM":
                        aluno.PostoGradCod = 5;
                        break;
                    case "2º TEN PM":
                        aluno.PostoGradCod = 6;
                        break;
                    case "ASP PM":
                        aluno.PostoGradCod = 7;
                        break;
                    case "SUB TEN PM":
                        aluno.PostoGradCod = 8;
                        break;
                    case "1ª SGT PM":
                        aluno.PostoGradCod = 9;
                        break;
                    case "2ª SGT PM":
                        aluno.PostoGradCod = 10;
                        break;
                    case "3ª SGT PM":
                        aluno.PostoGradCod = 11;
                        break;
                    case "CB PM":
                        aluno.PostoGradCod = 12;
                        break;
                    case "SD PM":
                        aluno.PostoGradCod = 13;
                        break;
                    case "SD 2ª CL PM":
                        aluno.PostoGradCod = 14;
                        break;

                    default:
                        aluno.PostoGradCod = 15;
                        break;
                }
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();

                if(file != null)
                {
                    if(aluno.Foto != null)
                    {
                        if(System.IO.File.Exists(Server.MapPath("~/" + aluno.Foto)))
                        {
                            System.IO.File.Delete(Server.MapPath("~/" + aluno.Foto));
                        }

                    }
                    String[] strName = file.FileName.Split('.');
                    String strExt = strName[strName.Count() - 1];
                    string pathSave = String.Format("{0}{1}.{2}", Server.MapPath("~/fotos/"), aluno.RE, strExt);
                    String pathBase = String.Format("/fotos/{0}.{1}", aluno.RE, strExt);
                    file.SaveAs(pathSave);
                    aluno.Foto = pathBase;
                    db.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluno aluno = db.Alunos.Find(id);
            db.Alunos.Remove(aluno);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
