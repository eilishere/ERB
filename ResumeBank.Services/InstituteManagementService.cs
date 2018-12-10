using ResumeBank.Entities;
using ResumeBank.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Services
{
    public class InstituteManagementService
    {
        private RBDbContext _rbDbContext;
        private InstituteUnitOfWork _instituteUnitOfWork;

        public InstituteManagementService()
        {
            _rbDbContext = new RBDbContext();
            _instituteUnitOfWork = new InstituteUnitOfWork(_rbDbContext);
        }

        public ICollection<Institute> GetAllInstitutes()
        {
            return _instituteUnitOfWork.InstituteRepository.GetAll();
        }
        public bool AddInstitute(Institute institute)
        {
            try
            {
                var newInstitute = new Institute();

                newInstitute.Id = newInstitute.Id;
                newInstitute.Name = newInstitute.Name;

                _instituteUnitOfWork.InstituteRepository.Add(newInstitute);
                _instituteUnitOfWork.Save();

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
