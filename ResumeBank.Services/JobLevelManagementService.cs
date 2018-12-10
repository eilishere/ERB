using ResumeBank.Entities;
using ResumeBank.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Services
{
    public class JobLevelManagementService
    {
        private RBDbContext _rbDbContext;
        private JobLevelUnitOfWork _jobLevelUnitOfWork;

        public JobLevelManagementService()
        {
            _rbDbContext = new RBDbContext();
            _jobLevelUnitOfWork = new JobLevelUnitOfWork(_rbDbContext);
        }

        public ICollection<JobLevel> GetAllJobLevels()
        {
            return _jobLevelUnitOfWork.JobLevelRepository.GetAll();
        }
        public bool AddJobLevel(JobLevel jobLevel)
        {
            try
            {
                var newjobLevel = new JobLevel();

                newjobLevel.Id = jobLevel.Id;
                newjobLevel.Name = jobLevel.Name;

                _jobLevelUnitOfWork.JobLevelRepository.Add(newjobLevel);
                _jobLevelUnitOfWork.Save();

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
