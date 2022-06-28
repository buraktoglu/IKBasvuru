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
        public JobApplicationRepository()
        {
        }

        public List<ApplicationListVM> GetListOfApplications()
        {
            List<ApplicationListVM> list = new List<ApplicationListVM>();

            foreach (var item in this.GetAll(e => e.IsActive == true))
            {
                ApplicationListVM vm = new ApplicationListVM()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    ApplicationStatus = item.ApplicationStatus,
                    Note = item.Note,
                    FileName = item.FileName,
                    FilePath = item.FilePath
                };

                list.Add(vm);
            }
            
            return list;
        }
    }
}
