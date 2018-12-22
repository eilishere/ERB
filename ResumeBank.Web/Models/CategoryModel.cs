using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using ResumeBank.Entities;
using ResumeBank.Services;

namespace ResumeBank.Web.Models
{
    public class CategoryModel : Category
    {

        private CategoryManagementService _categoryManagementService;
        public ICollection<Category> ParentCategories { get; set; }
        public ICollection<Category> Categories { get; set; }


        public IPagedList<Category> CategoriesPagedList { get; set; }
        public int? PageNumber { get; set; }

        public CategoryModel()
        {
            _categoryManagementService = new CategoryManagementService();
            ParentCategories = _categoryManagementService.GetAllCategories().Where(x => x.ParentId == null).ToList();
            Categories = _categoryManagementService.GetAllCategories().ToList();
        }

        public CategoryModel(int? id) : this()
        {
            if (id != null)
            {
                var existingCategory = _categoryManagementService.GetCategoryById(id.Value);

                Id = existingCategory.Id;
                Name = existingCategory.Name;
                ParentId = existingCategory.ParentId;
                ParentCategory = existingCategory.ParentCategory;
            }
        }

        public void AddCategory()
        {
            _categoryManagementService.AddCategory(this);
        }

        public void UpdateCategory()
        {
            _categoryManagementService.UpdateCategory(this);
        }

        public bool DeleteCategoryById(int id)
        {
            return _categoryManagementService.DeleteCategoryById(id);
        }

        public void SetAllCategoriesBySearch()
        {
            Categories = _categoryManagementService.GetAllCategories().ToList();
            Categories = !String.IsNullOrEmpty(Name) ? Categories.Where(c => c.Name.ToLower().Contains(Name.ToLower())).ToList() : Categories;
            Categories = ParentId == -1 ? Categories.Where(c => c.ParentId == null).ToList() : 
                (ParentId != 0 && ParentId != null ? Categories.Where(c => c.ParentId == ParentId).ToList() : Categories);

            ParentCategories = _categoryManagementService.GetAllCategories().Where(c => c.ParentId == null).ToList();

            var parent = new Category() { Id = -1, Name = "Parent Category" };
            ParentCategories.Add(parent);
        }

        public void SetAllCategoriesBySearchWithPaging()
        {
            SetAllCategoriesBySearch();

            int pageSize = 10;
            int pageNumber = (PageNumber ?? 1);
            CategoriesPagedList = Categories.ToPagedList(pageNumber, pageSize);
        }
    }
}