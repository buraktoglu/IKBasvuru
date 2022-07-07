﻿using IKBasvuru.COMMON.Enums;
using IKBasvuru.CORE.Validations;
using IKBasvuru.DATA.Domain;
using IKBasvuru.DATA.Repositories.Abstract;
using IKBasvuru.DATA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using IKBasvuru.UI.Common;

namespace IKBasvuru.UI.Controllers
{

    public class UserController : Controller
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IJobPositionRepository _jobPositionRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAgreementRepository _agreementRepository;

        public UserController(IJobApplicationRepository jobApplicationRepository, IJobPositionRepository jobPositionRepository, IWebHostEnvironment webHostEnvironment, IAgreementRepository agreementRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _jobPositionRepository = jobPositionRepository;
            _webHostEnvironment = webHostEnvironment;
            _agreementRepository = agreementRepository;
        }

        [HttpGet]
        public IActionResult Application()
        {
            OutputMessages outputMessage = HttpContext.Session.MySessionGet<OutputMessages>("applicationModalMessage");

            ApplicationVM applicationVM = new ApplicationVM()
            {
                JobPositions = _jobPositionRepository.GetAll(x => x.IsActive == true),
                Text = _agreementRepository.Get(x => x.IsActive == true).Text,
                OutputMessage = outputMessage
            };

            return View(applicationVM);
        }

        [HttpPost]
        public IActionResult Application(ApplicationVM applicationVM)
        {
            string randomName;
            string extent;
            string path;

            if (applicationVM.FormFile != null)
            {
                extent = Path.GetExtension(applicationVM.FormFile.FileName);
                randomName = ($"{Guid.NewGuid()}{extent}");

                // path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\CVs\\", randomName);

                string webRootPath = _webHostEnvironment.WebRootPath;
                path = Path.Combine(webRootPath, "CVs", randomName);
            }
            else
            {
                HttpContext.Session.MySessionSet("applicationModalMessage", OutputMessages.FileError);

                return RedirectToAction("Application", "User");
            }

            JobApplication jobApplication = new JobApplication()
            {
                Name = applicationVM.Name,
                Surname = applicationVM.Surname,
                Gender = applicationVM.Gender,
                BirthDate = applicationVM.BirthDate,
                MaritalStatus = applicationVM.MaritalStatus,
                KVKKCheck = applicationVM.KVKKCheck,
                MilitaryService = applicationVM.MilitaryStatus,
                Email = applicationVM.Email,
                PhoneNumber = applicationVM.PhoneNumber,
                Address = applicationVM.Address,
                JobPositionId = applicationVM.JobPositionId,
                FilePath = path,
                FileName = randomName
            };

            try
            {
                extent = extent.ToLower();

                if (extent == ".pdf" || extent == ".doc" || extent == ".docx" || extent == ".xls" || extent == ".xlsx" || extent == ".odt" || extent == ".rtf")
                {
                    var validate = new JobApplicationValidator().Validate(jobApplication);

                    if (validate.IsValid)
                    {
                        int affectedRow = _jobApplicationRepository.Add(jobApplication);

                        if (affectedRow == 1)
                        {
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                applicationVM.FormFile.CopyTo(stream);
                            }

                            HttpContext.Session.MySessionSet("applicationModalMessage", OutputMessages.Success);

                        }
                        else
                        {
                            HttpContext.Session.MySessionSet("applicationModalMessage", OutputMessages.Failure);
                        }

                    }
                    else
                    {
                        HttpContext.Session.MySessionSet("applicationModalMessage", OutputMessages.FormatError);
                    }
                }
                else
                {
                    HttpContext.Session.MySessionSet("applicationModalMessage", OutputMessages.ExtensionError);

                }


            }
            catch (Exception)
            {
                HttpContext.Session.MySessionSet("applicationModalMessage", OutputMessages.Failure);

                throw;
            }

            return RedirectToAction("Application", "User");
        }
    }
}
