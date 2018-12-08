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
                    return RedirectToAction("Search");
                }
                else
                {
                    candidateModel.AddCandidate();
                    return RedirectToAction("AddCandidate");
                }  
            }

            return View(candidateModel);
        }

        public ActionResult Search()
        {
            return View(_candidateModel.GetAllCandidates());
        }


    }
}