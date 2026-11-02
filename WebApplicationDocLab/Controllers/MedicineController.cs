using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationDocLab.Context;
using WebApplicationDocLab.Models;

namespace WebApplicationDocLab.Controllers
{
    public class MedicineController : Controller
    {
        private DoctorLab _contextdb;

        public MedicineController()
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

        // GET: Medicine
        public ActionResult Index()
        {
            return View(_contextdb.Medicines.ToList());
        }

        public ActionResult Details(int id)
        {
            var medicine = _contextdb.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Medicine medicine, HttpPostedFileBase ImageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(medicine);
            }

            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(ImageFile.FileName)}";
                var directoryPath = Server.MapPath("~/image/MedicineImage/");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                var path = Path.Combine(directoryPath, fileName);
                ImageFile.SaveAs(path);
                medicine.ImageUrl = fileName;
            }

            try
            {
                _contextdb.Medicines.Add(medicine);
                _contextdb.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                return View(medicine);
            }
        }

        public ActionResult Edit(int id)
        {
            var medicine = _contextdb.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Medicine medicine, HttpPostedFileBase ImageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(medicine);
            }

            var existingMedicine = _contextdb.Medicines.Find(id);
            if (existingMedicine == null)
            {
                return HttpNotFound();
            }

            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(ImageFile.FileName)}";
                var directoryPath = Server.MapPath("~/image/MedicineImage/");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                var path = Path.Combine(directoryPath, fileName);
                ImageFile.SaveAs(path);
                medicine.ImageUrl = fileName;
            }
            else
            {
                medicine.ImageUrl = existingMedicine.ImageUrl;
            }

            try
            {
                existingMedicine.MedicineName = medicine.MedicineName;
                existingMedicine.Description = medicine.Description;
                existingMedicine.GenericName = medicine.GenericName;
                existingMedicine.MedicineCategory = medicine.MedicineCategory;
                existingMedicine.Category = medicine.Category;
                existingMedicine.BrandName = medicine.BrandName;
                existingMedicine.ImageUrl = medicine.ImageUrl;

                _contextdb.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                return View(medicine);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var medicine = _contextdb.Medicines.Find(id);
            if (medicine == null)
            {
                TempData["DeleteError"] = "The medicine could not be found.";
                return RedirectToAction("Index");
            }

            try
            {
                _contextdb.Medicines.Remove(medicine);
                _contextdb.SaveChanges();
                TempData["DeleteSuccess"] = "The medicine has been deleted successfully.";
            }
            catch (Exception ex)
            {
                TempData["DeleteError"] = "An error occurred while deleting the medicine: " + ex.Message;
            }

            return RedirectToAction("Index");
        }

    }
}
