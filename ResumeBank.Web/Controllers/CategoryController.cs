using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeBank.Web.Models;

namespace ResumeBank.Web.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryModel _categoryModel;
        //
        // GET: /Category/

        public CategoryController()
        {
            _categoryModel = new CategoryModel();
        }

        [HttpGet]
        // Add new Candidate
        public ActionResult AddCategory(int? id)
        {
            if (id != null)
            {
                _categoryModel = new CategoryModel(id);
            }
            return View(_categoryModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(CategoryModel categoryModel)
        {

            if (ModelState.IsValid)
            {
                if (categoryModel.Id != 0 && categoryModel.Id != null)
                {
                    categoryModel.UpdateCategory();
                    TempData["notifyMessage"] = "<script>$.notify('Succesfully Updated', 'success');</script>";
                    return RedirectToAction("Categories");
                }
                else
                {
                    categoryModel.AddCategory();
                    TempData["notifyMessage"] = "<script>$.notify('Succesfully Added', 'success');</script>";
                    return RedirectToAction("AddCategory");
                }
            }

            TempData["notifyMessage"] = "<script>$.notify('Failed', 'error');</script>";
            return View(categoryModel);
        }

        [HttpGet]
        public ActionResult Categories(CategoryModel categoryModel)
        {
            categoryModel = categoryModel != null ? categoryModel : new CategoryModel();
            categoryModel.SetAllCategoriesBySearchWithPaging();
            return View(categoryModel);
        }

        public ActionResult DeleteCategory(int id)
        {
            var isDeleted = _categoryModel.DeleteCategoryById(id);
            if (isDeleted)
                TempData["notifyMessage"] = "<script>$.notify('Succesfully Deleted', 'success');</script>";
            return Json(isDeleted, JsonRequestBehavior.AllowGet);
        }
	}
}