using PagedList;
using ResumeBank.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace ResumeBank.Web.Controllers
{
    public class CandidateController : Controller
    {
        private CandidateModel _candidateModel;

        public CandidateController()
        {
            _candidateModel = new CandidateModel();
        }

        // GET: Candidate
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        // Add new Candidate
        public ActionResult AddCandidate(int? id)
        {
            if (id != null)
            {
                _candidateModel = new CandidateModel(id);
            }
            return View(_candidateModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCandidate(CandidateModel candidateModel)
        {

            if(ModelState.IsValid)
            {
                if (candidateModel.Id != 0 && candidateModel.Id  != null)
                {
                    candidateModel.UpdateCandidate();
                    TempData["notifyMessage"] = "<script>$.notify('Update succesfully', 'success');</script>";
                    return RedirectToAction("Search");
                }
                else
                {
                    candidateModel.AddCandidate();
                    TempData["notifyMessage"] = "<script>$.notify('Add succesfully', 'success');</script>";
                    return RedirectToAction("AddCandidate");
                }  
            }

            TempData["notifyMessage"] = "<script>$.notify('Failed', 'error');</script>";
            return View(candidateModel);
        }

        [HttpGet]
        public ActionResult Search(CandidateModel candidateModel)
        {
            candidateModel = candidateModel != null ? candidateModel : new CandidateModel();
            candidateModel.SetAllCandidatesBySearchWithPaging();
            return View(candidateModel);
        }

        public ActionResult DeleteCandidate(int id)
        {
            var isDeleted = _candidateModel.DeleteCandidateById(id);

            return Json(isDeleted, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSubCategories(int id)
        {
            var subCategory = _candidateModel.GetSubCategories(id);
            return Json(subCategory, JsonRequestBehavior.AllowGet);
        }

    }
}