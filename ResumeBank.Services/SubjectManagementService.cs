using ResumeBank.Entities;
using ResumeBank.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Services
{
    public class SubjectManagementService
    {
        private RBDbContext _rbDbContext;
        private SubjectUnitOfWork _subjectUnitOfWork;

        public SubjectManagementService()
        {
            _rbDbContext = new RBDbContext();
            _subjectUnitOfWork = new SubjectUnitOfWork(_rbDbContext);
        }

        public IEnumerable<Subject> GetAllSubject()
        {
            return _subjectUnitOfWork.SubjectRepository.GetAll();
        }
        public bool AddSubject(Subject subject)
        {
            try
            {
                var newSubject = new Subject();

                newSubject.Id = subject.Id;
                newSubject.Name = subject.Name;

                _subjectUnitOfWork.SubjectRepository.Add(newSubject);
                _subjectUnitOfWork.Save();

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
