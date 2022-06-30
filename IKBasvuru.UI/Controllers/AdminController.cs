using IKBasvuru.CORE.Validations;
using IKBasvuru.DATA.Domain;
using IKBasvuru.DATA.Repositories.Abstract;
using IKBasvuru.DATA.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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

       // [Authorize(Policy = "Require.Ldap.User", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        [HttpGet]
        public IActionResult ListApplications()
        {
            List<ApplicationListVM> applicationListVMs = _jobApplicationRepository.GetListOfApplications();

            return View(applicationListVMs);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            JobApplication jobApplication = _jobApplicationRepository.Get(e => e.Id == Id);

            ApplicationDetailsVM detailsVM = _jobApplicationRepository.GetDetails(Id);

            return View(detailsVM);
        }

        [HttpPost]
        public IActionResult Details(ApplicationDetailsVM detailsVM)
        {
            JobApplication jobApplication = _jobApplicationRepository.Get(e => e.Id == detailsVM.Id);
            
            jobApplication.Note = detailsVM.Note;
            jobApplication.ApplicationStatus = detailsVM.ApplicationStatus;

            try
            {
                _jobApplicationRepository.Update(jobApplication);
                //todo : modifiedby ve modifieddate güncellenmeli - accountcontroller implemente edildikten sonra
            }
            catch (Exception)
            {
                throw;
            }


            return RedirectToAction("ListApplications", "Admin");
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

            try
            {
                _jobApplicationRepository.Delete(jobApplication);
            }
            catch (Exception)
            {
                throw;
            }

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

            try
            {
                var validate = new JobPositionValidator().Validate(jobPosition);

                if (validate.IsValid)
                {
                    _jobPositionRepository.Add(jobPosition);

                }
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("ListPositions", "Admin");
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

            try
            {
                var validate = new JobPositionValidator().Validate(jobPosition);

                if (validate.IsValid)
                {
                    _jobPositionRepository.Update(jobPosition);

                }
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("ListPositions", "Admin");
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
            JobPosition jobPositionDeleted = _jobPositionRepository.Get(x => x.Id == jobPosition.Id && x.IsActive == true);

            try
            {
                _jobPositionRepository.Delete(jobPositionDeleted);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("ListPositions", "Admin");
        }
    }
}
