using IKBasvuru.COMMON.Enums;
using IKBasvuru.DATA.Domain;
using IKBasvuru.DATA.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IKBasvuru.UI.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;

        public ApplicationController(IJobApplicationRepository jobApplicationRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
        }

        public IActionResult Index()
        {
            //test insertion


            //JobApplication jatest = new JobApplication()
            //{
            //    Name = "burak",
            //    Surname = "tokatlioglu",
            //    Gender = Gender.Male,
            //    BirthDate = DateTime.Now,
            //    MaritalStatus = MaritalStatus.Single,
            //    KVKKCheck = true,
            //    Email = "buraktoglu@gmail.com",
            //    PhoneNumber = "5317030765",
            //    Address = "ist",
            //    JobPositionId = 1,
            //    FilePath ="/path"
            //};

            //_jobApplicationRepository.Add(jatest);


            return View();
        }
    }
}
