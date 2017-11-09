using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalMVC.Models;
using System.Net;
namespace ProyectoFinalMVC.Controllers
{
    public class CarsController : Controller
    {
        private ProyectoFinalMVC.Models.bd_proyectomvcEntities bd = new ProyectoFinalMVC.Models.bd_proyectomvcEntities();
        // GET: Cars
        public ActionResult Index()
        {
            return View(bd.carros.ToList());
        }

        // GET: Cars/Details/5'
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carros car = new carros();
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,modelo,marca,kilometraje,velocidad,estado,placa,precio")] carros cars)
        {
            if (ModelState.IsValid)
            {
                bd.carros.Add(cars);
                bd.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cars);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carros cars = bd.carros.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,modelo,marca,kilometraje,velocidad,estado,placa,precio")] carros cars)
        {
            if (ModelState.IsValid)
            {
                bd.Entry(cars).State = System.Data.Entity.EntityState.Modified;
                bd.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cars);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carros cars = bd.carros.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            carros cars = bd.carros.Find(id);
            bd.carros.Remove(cars);
            bd.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bd.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
