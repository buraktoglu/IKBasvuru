using IKBasvuru.COMMON.Enums;
using IKBasvuru.CORE.Validations;
using IKBasvuru.DATA.Domain;
using IKBasvuru.DATA.Repositories.Abstract;
using IKBasvuru.DATA.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IKBasvuru.UI.Controllers
{

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
                JobPositions = _jobPositionRepository.GetAll(x => x.IsActive == true),
            });
        }

        [HttpPost]
        public IActionResult Application(ApplicationVM applicationVM)
        {
            if (applicationVM.FormFile != null)
            {
                var extent = Path.GetExtension(applicationVM.FormFile.FileName);
                var fileName = 
            }

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
                FilePath = "/test-file-path",
                FileName = "/test-file-name"
            };

            try
            {
                new JobApplicationValidator().Validate(jobApplication);
                _jobApplicationRepository.Add(jobApplication);
            }
            catch (Exception)
            {
                throw;
            }
            

            //Log

            return RedirectToAction("Application", "User");
        }
    }
}
