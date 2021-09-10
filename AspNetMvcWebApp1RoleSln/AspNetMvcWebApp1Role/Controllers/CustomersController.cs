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
    public class CustomersController : Controller
    {
        private Model1 db = new Model1();

        // GET: Customers
        public async Task<ActionResult> Index()
        {
            return View(await db.TblCustomers.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCustomer tblCustomer = await db.TblCustomers.FindAsync(id);
            if (tblCustomer == null)
            {
                return HttpNotFound();
            }
            return View(tblCustomer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CustomerID,CustomerName,Phone")] TblCustomer tblCustomer)
        {
            if (ModelState.IsValid)
            {
                var customerId = db.TblCustomers.Max(o => (int?)o.CustomerID) ?? 0;
                var oTblCustomer = new TblCustomer();
                oTblCustomer.CustomerID = customerId + 1;
                oTblCustomer.CustomerName = tblCustomer.CustomerName;
                oTblCustomer.Phone = tblCustomer.Phone;
                db.TblCustomers.Add(oTblCustomer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tblCustomer);
        }

        // GET: Customers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCustomer tblCustomer = await db.TblCustomers.FindAsync(id);
            if (tblCustomer == null)
            {
                return HttpNotFound();
            }
            return View(tblCustomer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CustomerID,CustomerName,Phone")] TblCustomer tblCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCustomer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblCustomer);
        }

        // GET: Customers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCustomer tblCustomer = await db.TblCustomers.FindAsync(id);
            if (tblCustomer == null)
            {
                return HttpNotFound();
            }
            return View(tblCustomer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TblCustomer tblCustomer = await db.TblCustomers.FindAsync(id);
            db.TblCustomers.Remove(tblCustomer);
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
