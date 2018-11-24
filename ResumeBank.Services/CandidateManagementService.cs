using ResumeBank.Entities;
using ResumeBank.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Services
{
    public class CandidateManagementService
    {
        private RBDbContext _rbDbContext;
        private CandidateUnitOfWork _candidateUnitOfWork;

        public CandidateManagementService()
        {
            _rbDbContext = new RBDbContext();
            _candidateUnitOfWork = new CandidateUnitOfWork(_rbDbContext);
        }

        public bool AddCandidate(Candidate candidate)
        {
            try
            {
                var newCandidate = new Candidate();

                newCandidate.Id = candidate.Id;
                newCandidate.Name = candidate.Name;
                newCandidate.Email = candidate.Email;
                newCandidate.Address = candidate.Address;
                newCandidate.Phone = candidate.Phone;
                newCandidate.DateOfBirth = candidate.DateOfBirth;
                newCandidate.CurrentSalary = candidate.CurrentSalary;
                newCandidate.ExpectedSalary = candidate.ExpectedSalary;
                newCandidate.Training = candidate.Training;
                newCandidate.Gender = candidate.Gender;
                newCandidate.PrimaryCategory = candidate.PrimaryCategory;
                newCandidate.SubCategories = candidate.SubCategories;
                newCandidate.EducationLevel = candidate.EducationLevel;
                newCandidate.Subject = candidate.Subject;
                newCandidate.Institute = candidate.Institute;
                newCandidate.JobLevel = candidate.JobLevel;
                newCandidate.OriginalResume = candidate.OriginalResume;
                newCandidate.ModifiedResume = candidate.ModifiedResume;

                _candidateUnitOfWork.CandidateRepository.Add(newCandidate);
                _candidateUnitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
