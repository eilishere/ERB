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
            return _categoryUnitOfWork.CategoryRepository.GetAll().OrderBy(c => c.Name).ToList();
        }

        public IEnumerable<Category> GetAllSubCategories(int id)
        {
            return _categoryUnitOfWork.CategoryRepository.GetAllSubCategories(id).OrderBy(c => c.Name).ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryUnitOfWork.CategoryRepository.GetById(id);
        }

        public bool AddCategory(Category category)
        {
            try
            {
                var newCategory = new Category();

                newCategory.Id = category.Id;
                newCategory.Name = category.Name;
                newCategory.ParentId = category.ParentId;
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

        public bool UpdateCategory(Category category)
        {
            try
            {
                var updateCategory = new Category()
                {

                    Id = category.Id,
                    Name = category.Name,
                    ParentId = category.ParentId,
                    UpdatedAt = DateTime.Now
                };

                _categoryUnitOfWork.CategoryRepository.Update(updateCategory);
                _categoryUnitOfWork.Save();

                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteCategoryById(int id)
        {
            try
            {
                _categoryUnitOfWork.CategoryRepository.DeleteById(id);
                _categoryUnitOfWork.Save();
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
