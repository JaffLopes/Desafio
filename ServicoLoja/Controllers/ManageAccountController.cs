using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Net;
using System.Web.Mvc;

namespace ServicoLoja.Controllers
{
    //[RoutePrefix("api/Account")]
    public class ManageAccountController : Controller
    {
        [AllowAnonymous]
        [Route("Login")]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [AllowAnonymous]
        [Route("Register")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            AuthenticationManager.Unregister(DefaultAuthenticationTypes.ApplicationCookie);
            //AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // GET: MenageAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenageAccount/Create
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

        // GET: MenageAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MenageAccount/Edit/5
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

        // GET: MenageAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MenageAccount/Delete/5
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
