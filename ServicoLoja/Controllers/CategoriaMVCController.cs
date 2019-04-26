using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServicoLoja.Controllers
{
    public class CategoriaMVCController : Controller
    {
        public CategoriaMVCController()
        {

        }

        // GET: CategoriaMVC
        public ActionResult Index()
        {
            return View();
        }

        // GET: CategoriaMVC/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriaMVC/Create
        public ActionResult TelaCategoria()
        {
            return View();
        }

        // POST: CategoriaMVC/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaMVC/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoriaMVC/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaMVC/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoriaMVC/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
