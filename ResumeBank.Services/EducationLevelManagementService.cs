using ResumeBank.Entities;
using ResumeBank.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Services
{
    public class EducationLevelManagementService
    {
        private RBDbContext _rbDbContext;
        private EducationLevelUnitOfWork _educationLevelUnitOfWork;

        public EducationLevelManagementService()
        {
            _rbDbContext = new RBDbContext();
            _educationLevelUnitOfWork = new EducationLevelUnitOfWork(_rbDbContext);
        }

        public ICollection<EducationLevel> GetAllEducationLevels()
        {
            return _educationLevelUnitOfWork.EducationLevelRepository.GetAll();
        }

        public bool AddEducationLevel(EducationLevel educationLevel)
        {
            try
            {
                var newEducationLevel = new EducationLevel();

                newEducationLevel.Id = educationLevel.Id;
                newEducationLevel.Name = educationLevel.Name;
                
                newEducationLevel.UpdatedAt = DateTime.Now;

                _educationLevelUnitOfWork.EducationLevelRepository.Add(newEducationLevel);
                _educationLevelUnitOfWork.Save();

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
