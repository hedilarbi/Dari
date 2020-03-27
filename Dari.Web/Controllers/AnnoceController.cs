using Dari.Data.Infrastructure;
using Dari.Domain.Entities;
using Dari.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dari.Web.Controllers
{
    public class AnnoceController : Controller
    {
        IDataBaseFactory dbf;
        IUnitOfWork uow;
        IService<Annonce> ServiceAnnonce;
        IService<Client> ServiceClient;
        public AnnoceController()
        {
            dbf = new DataBaseFactory();
            uow = new UnitOfWork(dbf);
            ServiceAnnonce = new Service<Annonce>(uow);
            ServiceClient = new Service<Client>(uow);
        }
        // GET: Annoce
        public ActionResult Index()
        {
            return View(ServiceAnnonce.GetAll());
        }

        // GET: Annoce/Details/5
        public ActionResult Edit(int id)
        {
            return View(ServiceAnnonce.GetById(id));
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Annonce p)
        {
            try
            {
                // TODO: Add update logic here



                ServiceAnnonce.Update(p);
                ServiceAnnonce.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Annoce/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Annoce/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Annonce p, HttpPostedFileBase file)
        {

            // TODO: Add insert logic here
            p.images = file.FileName;
            ServiceAnnonce.Add(p);
            ServiceAnnonce.Commit();
            if (file.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/Content/upload/"), file.FileName);
                file.SaveAs(path);
            }
            return RedirectToAction("Index");


        }

       
       

        
      

        // GET: Annoce/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ServiceAnnonce.GetById(id));
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Annonce p)
        {
            try
            {
                // TODO: Add delete logic here
                p = ServiceAnnonce.GetById(id);
                ServiceAnnonce.Delete(p);
                ServiceAnnonce.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
