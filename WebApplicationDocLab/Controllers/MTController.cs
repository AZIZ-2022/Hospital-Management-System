using System.Linq;
using System.Web.Mvc;
using WebApplicationDocLab.Models;
using WebApplicationDocLab.Context;
using System.Data.Entity;

namespace WebApplicationDocLab.Controllers
{
    public class MTController : Controller
    {
        private DoctorLab _contextdb;
        public MTController()
        {
            _contextdb = new DoctorLab();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["UserEmail"] == null || Session["UserType"] == null || Session["UserType"].ToString() != "Admin")
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary {
                        { "controller", "Login" },
                        { "action", "Login" }
                    });
            }

            base.OnActionExecuting(filterContext);
        }

        // GET: MT
        public ActionResult Index()
        {
            return View(_contextdb.Tests.ToList());
        }

        // GET: MT/Details/5
        public ActionResult Details(int? id)
        {
            var test = _contextdb.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: MT/Edit/5
        public ActionResult Edit(int? id)
        {
            var test = _contextdb.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TestName,Category,Created_at")] Test test)
        {
            if (ModelState.IsValid)
            {
                _contextdb.Entry(test).State = EntityState.Modified;
                _contextdb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test);
        }

        // GET: MT/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MT/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TestName,Category,Created_at")] Test test)
        {
            if (ModelState.IsValid)
            {
                _contextdb.Tests.Add(test);
                _contextdb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test);
        }

        // GET: MT/Delete/5
        public ActionResult Delete(int? id)
        {
            var test = _contextdb.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var test = _contextdb.Tests.Find(id);
            if (test == null)
            {
                TempData["DeleteError"] = "The test could not be found.";
                return RedirectToAction("Delete", new { id });
            }

            try
            {
                _contextdb.Tests.Remove(test);
                _contextdb.SaveChanges();
                TempData["DeleteSuccess"] = "The test has been deleted successfully.";
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                TempData["DeleteError"] = "An error occurred while deleting the test: " + ex.Message;
                return RedirectToAction("Delete", new { id });
            }
        }


        public ActionResult TypeIndex()
        {
            return View(_contextdb.Doctor_Types.ToList());
        }

        public ActionResult TypeEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var doctorType = _contextdb.Doctor_Types.Find(id);
            if (doctorType == null)
            {
                return HttpNotFound();
            }
            return View(doctorType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TypeEdit([Bind(Include = "Id,TypeName")] Doctor_Type doctor_Type)
        {
            if (ModelState.IsValid)
            {
                var existingType = _contextdb.Doctor_Types.Find(doctor_Type.Id);
                if (existingType == null)
                {
                    return Json(new { success = false, message = "Doctor type not found" });
                }

                existingType.TypeName = doctor_Type.TypeName;
                _contextdb.SaveChanges();
                return RedirectToAction("TypeIndex");
            }
            return Json(new { success = false, message = "Invalid data" });
        }

        [HttpGet]
        public ActionResult TypeCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TypeCreate([Bind(Include = "Id,TypeName")] Doctor_Type doctor_Type)
        {
            if (ModelState.IsValid)
            {
                _contextdb.Doctor_Types.Add(doctor_Type);
                _contextdb.SaveChanges();
                return RedirectToAction("TypeIndex");
            }
            return Json(new { success = false, message = "Invalid data" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TypeDeleteConfirmed(int id)
        {
            var doctorType = _contextdb.Doctor_Types.Find(id);
            if (doctorType == null)
            {
                TempData["DeleteError"] = "The doctor type could not be found.";
                return RedirectToAction("TypeIndex");
            }

            try
            {
                _contextdb.Doctor_Types.Remove(doctorType);
                _contextdb.SaveChanges();
                TempData["DeleteSuccess"] = "The doctor type has been deleted successfully.";
            }
            catch (System.Exception ex)
            {
                TempData["DeleteError"] = "An error occurred while deleting the doctor type: " + ex.Message;
            }
            return RedirectToAction("TypeIndex");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _contextdb.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}
