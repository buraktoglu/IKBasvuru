using IKBasvuru.DATA.Domain;
using IKBasvuru.DATA.Repositories.Abstract;
using IKBasvuru.DATA.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IKBasvuru.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
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

            return View( new ApplicationListVM()
            {
                Id = jobApplication.Id,
                Name = jobApplication.Name,
                Surname = jobApplication.Surname
            });
        }

        [HttpPost]
        public IActionResult Delete(ApplicationListVM applicationListVM)
        {
            JobApplication jobApplication = _jobApplicationRepository.Get(x => x.Id == applicationListVM.Id);

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
            return View();
        }

        [HttpPost]
        public IActionResult AddPosition(int i)
        {
            return RedirectToAction("ListApplications", "Admin");
        }

        [HttpGet]
        public IActionResult UpdatePosition()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdatePosition(int i)
        {
            return RedirectToAction("ListApplications", "Admin");
        }

        [HttpGet]
        public IActionResult DeletePosition()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeletePosition(int i)
        {
            return RedirectToAction("ListApplications", "Admin");
        }
    }
}
