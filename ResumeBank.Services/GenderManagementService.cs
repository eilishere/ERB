using ResumeBank.Entities;
using ResumeBank.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Services
{
    public class GenderManagementService
    {
        private RBDbContext _rbDbContext;
        private GenderUnitOfWork _genderUnitOfWork;

        public GenderManagementService()
        {
            _rbDbContext = new RBDbContext();
            _genderUnitOfWork = new GenderUnitOfWork(_rbDbContext);
        }

        public IEnumerable<Gender> GetAllGender()
        {
            return _genderUnitOfWork.GenderRepository.GetAll();
        }
        public bool AddGender(Gender gender)
        {
            try
            {
                var newGender = new Gender();

                newGender.Id = gender.Id;
                newGender.Name = gender.Name;

                _genderUnitOfWork.GenderRepository.Add(newGender);
                _genderUnitOfWork.Save();

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
