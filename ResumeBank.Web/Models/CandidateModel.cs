using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using ResumeBank.Entities;
using ResumeBank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeBank.Web.Models
{
    public class CandidateModel : Candidate
    {
        
        private CandidateManagementService _candidateManagementService;
        private AttachmentManagementService _attachmentManagementService;
        private CategoryManagementService _categoryManagementService;
        private EducationLevelManagementService _educationLevelManagementService;
        private GenderManagementService _genderManagementService;
        private InstituteManagementService _instituteManagementService;
        private JobLevelManagementService _jobLevelManagementService;
        private SubjectManagementService _subjectManagementService;

        public ICollection<Category> PrimaryCategories { get; set; }
        public ICollection<Category> SubCategories { get; set; }
        public ICollection<EducationLevel> EducationLevels { get; set; }
        public ICollection<Gender> Genders { get; set; }
        public ICollection<Institute> Institutes { get; set; }
        public ICollection<JobLevel> JobLevels { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        [Display(Name = "Sub-Category")]
        public ICollection<int> SubCategorySelectedIds { get; set; }
        public HttpPostedFileBase OriginalResumeFile { get; set; }
        public HttpPostedFileBase ModifiedResumeFile { get; set; }
        
        public CandidateModel()
        {
            _candidateManagementService = new CandidateManagementService();
            _attachmentManagementService = new AttachmentManagementService();
            _categoryManagementService = new CategoryManagementService();
            _educationLevelManagementService = new EducationLevelManagementService();
            _genderManagementService = new GenderManagementService();
            _instituteManagementService = new InstituteManagementService();
            _jobLevelManagementService = new JobLevelManagementService();
            _subjectManagementService = new SubjectManagementService();

            PrimaryCategories = _categoryManagementService.GetAllCategories();
            SubCategories = PrimaryCategories;
            EducationLevels = _educationLevelManagementService.GetAllEducationLevels();
            Genders = _genderManagementService.GetAllGenders();
            Institutes = _instituteManagementService.GetAllInstitutes();
            JobLevels = _jobLevelManagementService.GetAllJobLevels();
            Subjects = _subjectManagementService.GetAllSubjects();
        }

        public CandidateModel(int? id) : this()
        {
            if(id != null)
            {
                var existingCandidate = _candidateManagementService.GetCandidateById(id.Value);

                Id = existingCandidate.Id;
                Name = existingCandidate.Name;
                Email = existingCandidate.Email;
                Phone = existingCandidate.Phone;
                Address = existingCandidate.Address;
                DateOfBirth = existingCandidate.DateOfBirth;
                CurrentSalary = existingCandidate.CurrentSalary;
                ExpectedSalary = existingCandidate.ExpectedSalary;
                TotalExperience = existingCandidate.TotalExperience;
                Keywords = existingCandidate.Keywords;
                Training = existingCandidate.Training;

                GenderId = existingCandidate.GenderId;
                PrimaryCategoryId = existingCandidate.PrimaryCategoryId;
                CandidateSubCategories = existingCandidate.CandidateSubCategories;
                EducationLevelId = existingCandidate.EducationLevelId;
                SubjectId = existingCandidate.SubjectId;
                InstituteId = existingCandidate.InstituteId;
                JobLevelId = existingCandidate.JobLevelId;
                OriginalResumeId = existingCandidate.OriginalResumeId;
                ModifiedResumeId = existingCandidate.ModifiedResumeId;
                OriginalResume = existingCandidate.OriginalResume;
                ModifiedResume = existingCandidate.ModifiedResume;
                SubCategorySelectedIds = CandidateSubCategories.Select(c => c.SubCategoryId).ToList();

            }
        }

        public void AddCandidate()
        {
            this.CandidateSubCategories = this.SubCategoryIdsToCandidateSubCategories();

            if (OriginalResumeFile != null && OriginalResumeFile.ContentLength > 0)
            {
                OriginalResume = new Attachment()
                {
                    OriginalName = Name,
                    Url = SaveResumeFile(OriginalResumeFile, Name + "_Orginal")
                };
            }

            if (ModifiedResumeFile != null && ModifiedResumeFile.ContentLength > 0)
            {
                ModifiedResume = new Attachment()
                {
                    OriginalName = Name,
                    Url = SaveResumeFile(ModifiedResumeFile, Name + "_Modified")
                };
            }

            _candidateManagementService.AddCandidate(this);
        }

        public void UpdateCandidate()
        {
            this.CandidateSubCategories = this.SubCategoryIdsToCandidateSubCategories();

            if (OriginalResumeFile != null && OriginalResumeFile.ContentLength > 0)
            {
                if (OriginalResumeId == 0 || OriginalResumeId == null)
                {
                    OriginalResume = new Attachment()
                    {
                        OriginalName = Name,
                        Url = SaveResumeFile(OriginalResumeFile, Name + "_Orginal")
                    };
                }
                else
                {
                    OriginalResume = _attachmentManagementService.GetAttachmentById(OriginalResumeId);
                    ExistingFileDelete(OriginalResume.Url);
                    OriginalResume.OriginalName = Name;
                    OriginalResume.Url = SaveResumeFile(OriginalResumeFile, Name + "_Orginal");
                }
            }

            if (ModifiedResumeFile != null && ModifiedResumeFile.ContentLength > 0)
            {
                if (ModifiedResumeId == 0 || ModifiedResumeId == null)
                {
                    ModifiedResume = new Attachment()
                    {
                        OriginalName = Name,
                        Url = SaveResumeFile(ModifiedResumeFile, Name + "_Modified")
                    };
                }
                else
                {
                    ModifiedResume = _attachmentManagementService.GetAttachmentById(ModifiedResumeId);
                    ExistingFileDelete(ModifiedResume.Url);
                    ModifiedResume.OriginalName = Name;
                    ModifiedResume.Url = SaveResumeFile(ModifiedResumeFile, Name + "_Modified");
                }
            }

            _candidateManagementService.UpdateCandidate(this);
        }

        public bool DeleteCandidateById(int id)
        {
            return _candidateManagementService.DeleteCandidateById(id);
        }

        public IEnumerable<Candidate> GetAllCandidates()
        {
            return _candidateManagementService.GetAllCandidates();
        }

        public ICollection<CandidateSubCategory> SubCategoryIdsToCandidateSubCategories()
        {
            ICollection<CandidateSubCategory> candidateSubCategories;

            candidateSubCategories = SubCategorySelectedIds!=null? SubCategorySelectedIds.Select(x => new CandidateSubCategory(){SubCategoryId = x}).ToList():null;

            return candidateSubCategories;
        }

        public string SaveResumeFile(HttpPostedFileBase file, string name)
        {
            string url = "";

            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    var allowedExtensions = new[] { ".pdf", ".doc", ".docx" };
                    var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    var fileExtensions = Path.GetExtension(file.FileName);

                    if (allowedExtensions.Contains(fileExtensions))
                    {
                        fileName = name.Replace(" ", "_") + "_" + Guid.NewGuid().ToString().Replace("-", "");
                        url = "~/Uploads/Resume//" + fileName + fileExtensions;
                        file.SaveAs(HttpContext.Current.Server.MapPath(url));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return url;
        }

        public bool ExistingFileDelete(string url)
        {
            if (File.Exists(HttpContext.Current.Server.MapPath(url)))
            {
                try
                {
                    File.Delete(HttpContext.Current.Server.MapPath(url));
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return true;
        }

    }
}