using IKBasvuru.DATA.Domain;
using IKBasvuru.DATA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.DATA.Repositories.Abstract
{
    public interface IJobApplicationRepository : IRepository<JobApplication>
    {
        public List<ApplicationListVM> GetListOfApplications();
    }
}
