using ResumeBank.Entities;
using ResumeBank.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Services
{
    public class CategoryManagementService
    {
        private RBDbContext _rbDbContext;
        private CategoryUnitOfWork _categoryUnitOfWork;

        public CategoryManagementService()
        {
            _rbDbContext = new RBDbContext();
            _categoryUnitOfWork = new CategoryUnitOfWork(_rbDbContext);
        }

        public ICollection<Category> GetAllCategories()
        {
            return _categoryUnitOfWork.CategoryRepository.GetAll();
        }

        public IEnumerable<Category> GetAllSubCategories(int id)
        {
            return _categoryUnitOfWork.CategoryRepository.GetAllSubCategories(id);
        }

        public bool AddCategory(Category category)
        {
            try
            {
                var newCategory = new Category();

                newCategory.Id = category.Id;
                newCategory.Name = category.Name;
                newCategory.ParentCategory = category.ParentCategory;
                newCategory.UpdatedAt = DateTime.Now;

                _categoryUnitOfWork.CategoryRepository.Add(newCategory);
                _categoryUnitOfWork.Save();

                return true;
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }
    }
}
