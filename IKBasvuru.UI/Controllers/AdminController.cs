using IKBasvuru.CORE.Validations;
using IKBasvuru.DATA.Domain;
using IKBasvuru.DATA.Repositories.Abstract;
using IKBasvuru.DATA.ViewModels;
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
                    //işlem başarılı
                }
                else
                {
                    //işlem başarısız
                }
            }
            catch (Exception)
            {
                //işlem başarısız

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

                if (affectedRow == 1)
                {
                    //işlem başarılı 
                }
                else
                {
                    //işlem başarısız
                }
            }
            catch (Exception)
            {
                //işlem başarısız

                throw;
            }

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
                        //işlem başarılı 
                    }
                    else
                    {
                        //işlem başarısız
                    }
                }
            }
            catch (Exception)
            {
                //işlem başarısız

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
                        //işlem başarılı 
                    }
                    else
                    {
                        //işlem başarısız
                    }
                }
            }
            catch (Exception)
            {
                //işlem başarısız

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

                if (affectedRow == 1)
                {
                    //işlem başarılı
                }
                else
                {
                    //işlem başarısız
                }
            }
            catch (Exception)
            {
                //işlem başarısız

                throw;
            }

            return RedirectToAction("ListPositions", "Admin");
        }
    }
}
