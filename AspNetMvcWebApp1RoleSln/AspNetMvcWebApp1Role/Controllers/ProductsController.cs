using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetMvcWebApp1Role.Models.Db;
using AspNetMvcWebApp1Role.Filters;

namespace AspNetMvcWebApp1Role.Controllers
{
    [TestActionFilter]
    public class ProductsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Products
        public async Task<ActionResult> Index()
        {
            return View(await db.TblProducts.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProduct tblProduct = await db.TblProducts.FindAsync(id);
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            return View(tblProduct);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductId,ProductName,Qty")] TblProduct tblProduct)
        {
            if (ModelState.IsValid)
            {
                var productId = db.TblProducts.Max(o => (int?)o.ProductId) ?? 0;
                var oTblProduct = new TblProduct();
                oTblProduct.ProductId = productId + 1;
                oTblProduct.ProductName = tblProduct.ProductName;
                oTblProduct.Qty = tblProduct.Qty;
                db.TblProducts.Add(oTblProduct);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tblProduct);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProduct tblProduct = await db.TblProducts.FindAsync(id);
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            return View(tblProduct);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductId,ProductName,Qty")] TblProduct tblProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProduct).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblProduct);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProduct tblProduct = await db.TblProducts.FindAsync(id);
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            return View(tblProduct);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TblProduct tblProduct = await db.TblProducts.FindAsync(id);
            db.TblProducts.Remove(tblProduct);
            await db.SaveChangesAsync();
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
