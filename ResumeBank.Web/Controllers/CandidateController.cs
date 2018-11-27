using ResumeBank.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeBank.Web.Controllers
{
    public class CandidateController : Controller
    {
        // GET: Candidate
        public ActionResult Index()
        {
            return View();
        }

        // Add new Candidate
        public ActionResult AddCandidate()
        {
            var candidateModel = new CandidateModel();
            return View(candidateModel);
        }
    }
}