using System.IO;
using System.Web;
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

        public IEnumerable<Candidate> GetAllCandidates()
        {
            return _candidateUnitOfWork.CandidateRepository.GetAll();
        }

        public Candidate GetCandidateById(int id)
        {
            return _candidateUnitOfWork.CandidateRepository.GetById(id);
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
                newCandidate.GenderId = candidate.GenderId;
                newCandidate.PrimaryCategoryId = candidate.PrimaryCategoryId;
                newCandidate.CandidateSubCategories = candidate.CandidateSubCategories;
                newCandidate.EducationLevelId = candidate.EducationLevelId;
                newCandidate.SubjectId = candidate.SubjectId;
                newCandidate.InstituteId = candidate.InstituteId;
                newCandidate.JobLevelId = candidate.JobLevelId;
                newCandidate.TotalExperience = candidate.TotalExperience;
                newCandidate.Keywords = candidate.Keywords;
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


        public bool UpdateCandidate(Candidate candidate)
        {
            try
            {
                var updateCandidate = new Candidate()
                {

                    Id = candidate.Id,
                    Name = candidate.Name,
                    Email = candidate.Email,
                    Address = candidate.Address,
                    Phone = candidate.Phone,
                    DateOfBirth = candidate.DateOfBirth,
                    CurrentSalary = candidate.CurrentSalary,
                    ExpectedSalary = candidate.ExpectedSalary,
                    Training = candidate.Training,
                    GenderId = candidate.GenderId,
                    PrimaryCategoryId = candidate.PrimaryCategoryId,
                    CandidateSubCategories = candidate.CandidateSubCategories,
                    EducationLevelId = candidate.EducationLevelId,
                    SubjectId = candidate.SubjectId,
                    InstituteId = candidate.InstituteId,
                    JobLevelId = candidate.JobLevelId,
                    TotalExperience = candidate.TotalExperience,
                    Keywords = candidate.Keywords,
                    OriginalResume = candidate.OriginalResume,
                    ModifiedResume = candidate.ModifiedResume
                };

                //if (updateCandidate.OriginalResume.Id != 0 && updateCandidate.OriginalResume.Id != null)
                //{
                    
                //}

                _candidateUnitOfWork.CandidateRepository.Update(updateCandidate);
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
