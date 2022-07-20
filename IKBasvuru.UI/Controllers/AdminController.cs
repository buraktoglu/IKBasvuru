using IKBasvuru.COMMON.Enums;
using IKBasvuru.CORE.Validations;
using IKBasvuru.DATA.Domain;
using IKBasvuru.DATA.Repositories.Abstract;
using IKBasvuru.DATA.ViewModels;
using IKBasvuru.UI.Common;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IKBasvuru.UI.Controllers
{
    [Authorize(Policy = "Require.Ldap.User", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class AdminController : Controller
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IJobPositionRepository _jobPositionRepository;
        private readonly IAgreementRepository _agreementRepository;

        public AdminController(IJobApplicationRepository jobApplicationRepository, IJobPositionRepository jobPositionRepository, IAgreementRepository agreementRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _jobPositionRepository = jobPositionRepository;
            _agreementRepository = agreementRepository;
        }

        [HttpGet]
        public IActionResult ListApplications()
        {
            var message = TempData["listModalMessage"];

            if (message == null)
            {
                TempData["listModalMessageType"] = "info";
                TempData["listModalMessage"] = "Hoşgeldiniz.";
            }

            List<ApplicationListVM> applications = _jobApplicationRepository.GetListOfApplications();

            return View(applications);
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
            jobApplication.ModifiedBy = User.Identity.Name;
            jobApplication.ModifiedDate = DateTime.Now;

            try
            {
                int affectedRow = _jobApplicationRepository.Update(jobApplication);

                if (affectedRow == 1)
                {
                    TempData["listModalMessageType"] = "success";
                    TempData["listModalMessage"] = "İşleminiz Başarılı.";
                }
                else
                {
                    TempData["listModalMessageType"] = "error";
                    TempData["listModalMessage"] = "İşleminiz Başarısız.";
                }
            }
            catch (Exception)
            {
                TempData["listModalMessageType"] = "error";
                TempData["listModalMessage"] = "İşleminiz Başarısız.";

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
                jobApplication.ModifiedBy = User.Identity.Name;
                jobApplication.ModifiedDate = DateTime.Now;
                int affectedRow = _jobApplicationRepository.Delete(jobApplication);

                TempData["listModalMessageType"] = "success";
                TempData["listModalMessage"] = "İşleminiz Başarılı.";

            }
            catch (Exception)
            {
                TempData["listModalMessageType"] = "error";
                TempData["listModalMessage"] = "İşleminiz Başarısız.";

                throw;
            }

            return RedirectToAction("ListApplications", "Admin");
        }

        [HttpGet]
        public IActionResult ListPositions()
        {
            var message = TempData["positionModalMessage"];

            if (message == null)
            {
                TempData["positionModalMessageType"] = "info";
                TempData["positionModalMessage"] = "Hoşgeldiniz.";
            }

            List<JobPosition> jobs = _jobPositionRepository.GetAll(x => x.IsActive == true);

            return View(jobs);
        }

        [HttpGet]
        public IActionResult AddPosition()
        {
            return View(new JobPosition());
        }

        [HttpPost]
        public IActionResult AddPosition(JobPosition jobPosition)
        {
            try
            {
                var validate = new JobPositionValidator().Validate(jobPosition);

                if (validate.IsValid)
                {
                    jobPosition.ModifiedBy = User.Identity.Name;
                    jobPosition.ModifiedDate = DateTime.Now;
                    int affectedRow = _jobPositionRepository.Add(jobPosition);

                    if (affectedRow == 1)
                    {
                        TempData["positionModalMessageType"] = "success";
                        TempData["positionModalMessage"] = "İşleminiz Başarılı.";
                    }
                    else
                    {
                        TempData["positionModalMessageType"] = "error";
                        TempData["positionModalMessage"] = "İşleminiz Başarısız.";
                    }
                }
            }
            catch (Exception)
            {
                TempData["positionModalMessageType"] = "error";
                TempData["positionModalMessage"] = "İşleminiz Başarısız.";

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
            try
            {
                var validate = new JobPositionValidator().Validate(jobPosition);

                if (validate.IsValid)
                {
                    jobPosition.ModifiedBy = User.Identity.Name;
                    jobPosition.ModifiedDate = DateTime.Now;
                    int affectedRow = _jobPositionRepository.Update(jobPosition);

                    if (affectedRow == 1)
                    {
                        TempData["positionModalMessageType"] = "success";
                        TempData["positionModalMessage"] = "İşleminiz Başarılı.";
                    }
                    else
                    {
                        TempData["positionModalMessageType"] = "error";
                        TempData["positionModalMessage"] = "İşleminiz Başarısız.";
                    }
                }
            }
            catch (Exception)
            {
                TempData["positionModalMessageType"] = "error";
                TempData["positionModalMessage"] = "İşleminiz Başarısız.";

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
                jobPosition.ModifiedBy = User.Identity.Name;
                jobPosition.ModifiedDate = DateTime.Now;
                int affectedRow = _jobPositionRepository.Delete(jobPositionDeleted);

                TempData["positionModalMessageType"] = "success";
                TempData["positionModalMessage"] = "İşleminiz Başarılı.";

            }
            catch (Exception)
            {
                TempData["positionModalMessageType"] = "error";
                TempData["positionModalMessage"] = "İşleminiz Başarısız.";

                throw;
            }

            return RedirectToAction("ListPositions", "Admin");
        }

        [HttpGet]
        public IActionResult Editor()
        {
            Agreement agreement = _agreementRepository.Get(x => x.IsActive == true);

            return View(agreement);
        }

        [HttpPost]
        public IActionResult Editor(Agreement agreement)
        {
            agreement.ModifiedDate = DateTime.Now;
            agreement.ModifiedBy = User.Identity.Name;

            int affectedRow = _agreementRepository.Update(agreement);

            return RedirectToAction("ListApplications", "Admin");
        }

    }
}
