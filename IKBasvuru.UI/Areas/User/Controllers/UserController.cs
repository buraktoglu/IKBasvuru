using IKBasvuru.COMMON.Enums;
using IKBasvuru.DATA.Domain;
using IKBasvuru.DATA.Repositories.Abstract;
using IKBasvuru.DATA.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IKBasvuru.UI.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IJobPositionRepository _jobPositionRepository;

        public UserController(IJobApplicationRepository jobApplicationRepository, IJobPositionRepository jobPositionRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _jobPositionRepository = jobPositionRepository;
        }

        [HttpGet]
        public IActionResult Application()
        {
            return View(new ApplicationVM()
            {
                JobPositions = _jobPositionRepository.GetAll(),

                Genders = new List<Gender>()
                {
                    Gender.Female,
                    Gender.Male,
                    Gender.Unknown
                },

                MaritalStatuses = new List<MaritalStatus>()
                {
                    MaritalStatus.Single,
                    MaritalStatus.Married,
                    MaritalStatus.Widow,
                    MaritalStatus.Divorced
                }
            });
        }

        [HttpPost]
        public IActionResult Application(ApplicationVM applicationVM)
        {
            //Auto-mapper implemente edilebilir

            JobApplication jobApplication = new JobApplication()
            {
                Name = applicationVM.Name,
                Surname = applicationVM.Surname,
                Gender = applicationVM.Gender,
                BirthDate = applicationVM.BirthDate,
                MaritalStatus = applicationVM.MaritalStatus,
                KVKKCheck = applicationVM.KVKKCheck,
                Email = applicationVM.Email,
                PhoneNumber = applicationVM.PhoneNumber,
                Address = applicationVM.Address,
                JobPositionId = applicationVM.JobPositionId,
                FilePath = "/asdasd"
            };

            _jobApplicationRepository.Add(jobApplication);

            //Log

            return RedirectToAction("Application", "User");
        }
    }
}
