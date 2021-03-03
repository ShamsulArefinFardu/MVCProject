using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCProject_ArefinFardu.Models;
using MVCProject_ArefinFardu.Models.ViewModel;
using System.Data.Entity;

namespace MVCProject_ArefinFardu.Controllers
{
    public class SupplierController : Controller
    {
        MVCProject_ArefinFarduEntities db = new MVCProject_ArefinFarduEntities();

        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetSupplier()
        {
            var supplier = db.Suppliers.AsEnumerable().Select(c => new { id = c.SupplierId, name = c.Name, address=c.Address, email = c.Email, phoneno = c.PhoneNo });
            return Json(supplier, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(SupplierVM supplier)
        {
            var result = false;
            if (ModelState.IsValid)
            {
                Supplier con = new Supplier();
                con.Name = supplier.Name;                
                con.Address = supplier.Address;
                con.Email = supplier.Email;
                con.PhoneNo = supplier.PhoneNo;
                db.Suppliers.Add(con);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            return View(supplier);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(Supplier supplier)
        {
            var result = false;
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int delId)
        {
            var result = false;
            if (ModelState.IsValid)
            {
                Supplier supplier = db.Suppliers.Find(delId);
                db.Suppliers.Remove(supplier);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}