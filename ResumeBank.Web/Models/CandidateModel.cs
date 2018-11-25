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

                Gender = existingCandidate.Gender;
                PrimaryCategory = existingCandidate.PrimaryCategory;
                SubCategories = existingCandidate.SubCategories;
                EducationLevel = existingCandidate.EducationLevel;
                Subject = existingCandidate.Subject;
                Institute = existingCandidate.Institute;
                JobLevel = existingCandidate.JobLevel;
                OriginalResume = existingCandidate.OriginalResume;
                ModifiedResume = existingCandidate.ModifiedResume;
            }
        }

        public void AddCandidate()
        {
            _candidateManagementService.AddCandidate(this);
        }

    }
}