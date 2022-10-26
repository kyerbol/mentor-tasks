using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetJSON.Controllers
{
    public class WeatheroController : Controller
    {
        // GET: WeatheroController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WeatheroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WeatheroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeatheroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WeatheroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WeatheroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WeatheroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WeatheroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
