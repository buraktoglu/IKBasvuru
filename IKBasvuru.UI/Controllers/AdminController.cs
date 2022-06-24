using IKBasvuru.DATA.Domain;
using IKBasvuru.DATA.Repositories.Abstract;
using IKBasvuru.DATA.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IKBasvuru.UI.Controllers
{

    public class AdminController : Controller
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IJobPositionRepository _jobPositionRepository;

        public AdminController(IJobApplicationRepository jobApplicationRepository, IJobPositionRepository jobPositionRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _jobPositionRepository = jobPositionRepository;
        }

        [HttpGet]
        public IActionResult ListApplications()
        {
            List<ApplicationListVM> applicationListVMs = _jobApplicationRepository.GetListOfApplications();

            return View(applicationListVMs);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            JobApplication jobApplication = _jobApplicationRepository.Get(x => x.Id == Id);

            return View(new ApplicationListVM()
            {
                Id = jobApplication.Id,
                Name = jobApplication.Name,
                Surname = jobApplication.Surname
            });
        }

        [HttpPost]
        public IActionResult Delete(ApplicationListVM applicationListVM)
        {
            JobApplication jobApplication = _jobApplicationRepository.Get(x => x.Id == applicationListVM.Id && x.IsActive == true);

            _jobApplicationRepository.Delete(jobApplication);

            //todo : modifiedby ve modifieddate güncellenmeli - accountcontroller implemente edildikten sonra

            return RedirectToAction("ListApplications", "Admin");
        }

        [HttpGet]
        public IActionResult ListPositions()
        {
            List<JobPosition> jobPositions = _jobPositionRepository.GetAll(x => x.IsActive == true);

            return View(jobPositions);
        }

        [HttpGet]
        public IActionResult AddPosition()
        {
            return View(new JobPosition());
        }

        [HttpPost]
        public IActionResult AddPosition(JobPosition jobPosition)
        {
            //todo : jobPosition.ModifiedBy after account controller

            _jobPositionRepository.Add(jobPosition);

            return RedirectToAction("ListApplications", "Admin");
        }

        [HttpGet]
        public IActionResult UpdatePosition(int Id)
        {
            JobPosition jobPosition = _jobPositionRepository.Get(x => x.Id == Id && x.IsActive == true);

            return View(jobPosition);
        }

        [HttpPost]
        public IActionResult UpdatePosition(JobPosition jobPosition)
        {
            //todo : jobPosition.ModifiedBy after account controller

            _jobPositionRepository.Update(jobPosition);

            return RedirectToAction("ListApplications", "Admin");
        }

        [HttpGet]
        public IActionResult DeletePosition(int Id)
        {
            JobPosition jobPosition = _jobPositionRepository.Get(x => x.Id == Id && x.IsActive == true);

            return View(jobPosition);
        }

        [HttpPost]
        public IActionResult DeletePosition(JobPosition jobPosition)
        {
            _jobPositionRepository.Delete(jobPosition);

            return RedirectToAction("ListApplications", "Admin");
        }
    }
}
