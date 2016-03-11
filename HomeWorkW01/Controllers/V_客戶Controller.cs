using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeWorkW01.Models;

namespace HomeWorkW01.Controllers
{
    public class V_客戶Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: V_客戶
        public ActionResult Index()
        {
            return View(db.V_客戶.ToList());
        }

        // GET: V_客戶/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            V_客戶 v_客戶 = db.V_客戶.Find(id);
            if (v_客戶 == null)
            {
                return HttpNotFound();
            }
            return View(v_客戶);
        }

        // GET: V_客戶/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: V_客戶/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "客戶名稱,聯絡人數量,銀行帳戶數量")] V_客戶 v_客戶)
        {
            if (ModelState.IsValid)
            {
                db.V_客戶.Add(v_客戶);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(v_客戶);
        }

        // GET: V_客戶/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            V_客戶 v_客戶 = db.V_客戶.Find(id);
            if (v_客戶 == null)
            {
                return HttpNotFound();
            }
            return View(v_客戶);
        }

        // POST: V_客戶/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "客戶名稱,聯絡人數量,銀行帳戶數量")] V_客戶 v_客戶)
        {
            if (ModelState.IsValid)
            {
                db.Entry(v_客戶).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(v_客戶);
        }

        // GET: V_客戶/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            V_客戶 v_客戶 = db.V_客戶.Find(id);
            if (v_客戶 == null)
            {
                return HttpNotFound();
            }
            return View(v_客戶);
        }

        // POST: V_客戶/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            V_客戶 v_客戶 = db.V_客戶.Find(id);
            db.V_客戶.Remove(v_客戶);
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
