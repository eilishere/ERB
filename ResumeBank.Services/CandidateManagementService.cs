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
        private AttachmentManagementService _attachmentManagementService;
        private CandidateSubCategoryService _candidateSubCategoryService;

        public CandidateManagementService()
        {
            _rbDbContext = new RBDbContext();
            _candidateUnitOfWork = new CandidateUnitOfWork(_rbDbContext);
            _attachmentManagementService = new AttachmentManagementService();
            _candidateSubCategoryService = new CandidateSubCategoryService();
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
                    OriginalResumeId = candidate.OriginalResumeId,
                    ModifiedResumeId = candidate.ModifiedResumeId,
                    OriginalResume = candidate.OriginalResume,
                    ModifiedResume = candidate.ModifiedResume
                };

                if (updateCandidate.OriginalResume != null)
                {
                    if (updateCandidate.OriginalResume.Id != 0 && updateCandidate.OriginalResume.Id != null)
                    {
                        _attachmentManagementService.UpdateAttachment(updateCandidate.OriginalResume);
                    }
                    else
                    {
                        _attachmentManagementService.AddAttachment(updateCandidate.OriginalResume);
                        updateCandidate.OriginalResumeId = updateCandidate.OriginalResume.Id;
                    }
                    updateCandidate.OriginalResume = null;
                }

                if (updateCandidate.ModifiedResume != null)
                {
                    if (updateCandidate.ModifiedResume.Id != 0 && updateCandidate.ModifiedResume.Id != null)
                    {
                        _attachmentManagementService.UpdateAttachment(updateCandidate.ModifiedResume);
                    }
                    else
                    {
                        _attachmentManagementService.AddAttachment(updateCandidate.ModifiedResume);
                        updateCandidate.ModifiedResumeId = updateCandidate.ModifiedResume.Id;
                    }
                    updateCandidate.ModifiedResume = null;
                }

                //List of Sub-Category update
                List<CandidateSubCategory> previousSubCategories = _candidateSubCategoryService.GetAllCandidateSubCategoryByCandidateId(updateCandidate.Id).ToList();
                List<CandidateSubCategory> currentSubCategories;
                List<CandidateSubCategory> deletableSubCategories = previousSubCategories.ToList();
                List<CandidateSubCategory> addableSubCategories;

                if (updateCandidate.CandidateSubCategories != null)
                {
                    currentSubCategories = updateCandidate.CandidateSubCategories.ToList();
                    deletableSubCategories = previousSubCategories.Except(currentSubCategories).ToList();
                    addableSubCategories = currentSubCategories.Where(c => c.Id == 0).ToList();
                    addableSubCategories.ForEach(c => { c.CandidateId = updateCandidate.Id; });
                    _candidateSubCategoryService.AddRangeCandidateSubCategories(addableSubCategories);
                }

                _candidateSubCategoryService.DeleteRangeCandidateSubCategoriesFromDatabaseByItems(deletableSubCategories);
                updateCandidate.CandidateSubCategories = null;

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

        public bool DeleteCandidateById(int id)
        {
            try
            {
                _candidateUnitOfWork.CandidateRepository.DeleteById(id);
                _candidateUnitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
    }
}
