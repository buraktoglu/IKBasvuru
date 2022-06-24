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
                    FileName = item.FileName
                };

                list.Add(vm);
            }
            
            return list;
        }
    }
}
