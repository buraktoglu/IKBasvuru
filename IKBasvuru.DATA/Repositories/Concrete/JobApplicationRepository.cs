using IKBasvuru.DATA.Context;
using IKBasvuru.DATA.Domain;
using IKBasvuru.DATA.Repositories.Abstract;
using IKBasvuru.DATA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.DATA.Repositories.Concrete
{
    public class JobApplicationRepository : Repository<JobApplication, IKBasvuruContext> , IJobApplicationRepository
    {
        private readonly IJobPositionRepository _jobPositionRepository;

        public JobApplicationRepository(IJobPositionRepository jobPositionRepository)
        {
            _jobPositionRepository = jobPositionRepository;
        }

        public List<ApplicationListVM> GetListOfApplications()
        {
            List<JobPosition> jobs = _jobPositionRepository.GetAll();
            List<ApplicationListVM> list = new List<ApplicationListVM>();

            foreach (var item in this.GetAll(e => e.IsActive == true))
            {
                ApplicationListVM vm = new ApplicationListVM()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    JobPosition = jobs[item.JobPositionId].Name,
                    ApplicationStatus = item.ApplicationStatus,
                    Note = item.Note,
                    FileName = item.FileName,
                    FilePath = item.FilePath
                };

                list.Add(vm);
            }
            
            return list;
        }

        public ApplicationDetailsVM GetDetails(int Id)
        {
            List<JobPosition> jobs = _jobPositionRepository.GetAll();

            JobApplication jobApplication = this.Get(e => e.Id == Id);

            return new ApplicationDetailsVM()
            {
                Id = jobApplication.Id,
                ApplicationStatus = jobApplication.ApplicationStatus,
                Address = jobApplication.Address,
                BirthDate = jobApplication.BirthDate,
                Email = jobApplication.Email,
                FileName = jobApplication.FileName,
                FilePath = jobApplication.FilePath,
                Gender = jobApplication.Gender,
                JobPosition = jobs[jobApplication.JobPositionId].Name,
                MaritalStatus = jobApplication.MaritalStatus,
                MilitaryStatus = jobApplication.MilitaryService,
                Name = jobApplication.Name,
                Surname = jobApplication.Surname,
                PhoneNumber = jobApplication.PhoneNumber,
                Note = jobApplication.Note
            };
        }
    }
}
