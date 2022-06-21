using IKBasvuru.DATA.Context;
using IKBasvuru.DATA.Domain;
using IKBasvuru.DATA.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.DATA.Repositories.Concrete
{
    public class JobApplicationRepository : Repository<JobApplication, IKBasvuruContext> , IJobApplicationRepository
    {
    }
}
