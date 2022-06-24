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

        public AdminController(IJobApplicationRepository jobApplicationRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
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

            return RedirectToAction("ListApplications", "Admin");
        }

        [HttpGet]
        public IActionResult ListPositions()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddPosition()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPosition(int i)
        {
            return RedirectToAction("Index", "Admin");
        }
    }
}
