using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResumeBank.Entities;
using ResumeBank.Repository;

namespace ResumeBank.Services
{
    public class CandidateSubCategoryService
    {
        private RBDbContext _rbDbContext;
        private CandidateSubCategoryUnitOfWork _candidateSubCategoryUnitOfWork;

        public CandidateSubCategoryService()
        {
            _rbDbContext = new RBDbContext();
            _candidateSubCategoryUnitOfWork = new CandidateSubCategoryUnitOfWork(_rbDbContext);
        }

        public ICollection<CandidateSubCategory> GetAllCandidateSubCategory()
        {
            return _candidateSubCategoryUnitOfWork.CandidateSubCategoryRepository.GetAll();
        }

        public ICollection<CandidateSubCategory> GetAllCandidateSubCategoryByCandidateId(int id)
        {
            return _candidateSubCategoryUnitOfWork.CandidateSubCategoryRepository.GetAll().Where(c => c.CandidateId == id).ToList();
        }

        public bool AddCandidateSubCategory(CandidateSubCategory candidateSubCategory)
        {
            try
            {
                _candidateSubCategoryUnitOfWork.CandidateSubCategoryRepository.Add(candidateSubCategory);
                _candidateSubCategoryUnitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool AddRangeCandidateSubCategories(ICollection<CandidateSubCategory> candidateSubCategories)
        {
            try
            {
                _candidateSubCategoryUnitOfWork.CandidateSubCategoryRepository.AddRange(candidateSubCategories);
                _candidateSubCategoryUnitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool UpdateRangeCandidateSubCategories(ICollection<CandidateSubCategory> candidateSubCategories)
        {
            try
            {
                _candidateSubCategoryUnitOfWork.CandidateSubCategoryRepository.UpdateRange(candidateSubCategories);
                _candidateSubCategoryUnitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteCandidateSubCategoryFromDatabaseByItem(CandidateSubCategory candidateSubCategory)
        {
            try
            {
                _candidateSubCategoryUnitOfWork.CandidateSubCategoryRepository.DeleteFromDatabaseByItem(candidateSubCategory);
                _candidateSubCategoryUnitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteRangeCandidateSubCategoriesFromDatabaseByItems(ICollection<CandidateSubCategory> candidateSubCategories)
        {
            try
            {
                _candidateSubCategoryUnitOfWork.CandidateSubCategoryRepository.DeleteRangeFromDatabaseByItems(candidateSubCategories);
                _candidateSubCategoryUnitOfWork.Save();

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
