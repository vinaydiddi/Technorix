using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using newmvccore.Models;

namespace newmvccore.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepo _emprepo;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(ILogger<HomeController> logger,IEmployeeRepo employeeRepo, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _emprepo = employeeRepo;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public ViewResult Index()
        {
            List<Employee> emp = _emprepo.listemployee().ToList();
            return View("Index", emp);
        }

        public IActionResult Details(int ?id)
        {
            //throw new Exception("hello moto");
            HomeDetailsModel homeDetailsModel = new HomeDetailsModel()
            {
                emplviewmodel = _emprepo.GetEmployee(id??1),
                title = "vinay"
            };
            return View(homeDetailsModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.photo != null)
                {
                    uniqueFileName = uploadphoto(model);
                }
                Employee newEmployee = new Employee
                {
                    name = model.name,
                    email = model.email,
                    department = model.department,
                    photopath = uniqueFileName
                };

                _emprepo.Addemployee(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.id });
            }
            return View();
        }

        private string uploadphoto(CreateViewModel model)
        {
            string uniqueFileName;
            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "image");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + model.photo.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            model.photo.CopyTo(new FileStream(filePath, FileMode.Create));
            return uniqueFileName;
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _emprepo.GetEmployee(id);
            EditViewModel employeeEditViewModel = new EditViewModel 
            { 
                id=employee.id,
                name=employee.name,
                department=employee.department,
                email=employee.email
            };
            return View(employeeEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee
                {
                    id = editViewModel.id,
                    name = editViewModel.name,
                    department = editViewModel.department,
                    email = editViewModel.email
                };

                if (editViewModel.photo != null)
                {
                    // If a new photo is uploaded, the existing photo must be
                    // deleted. So check if there is an existing photo and delete
                    if (editViewModel.existingphotopath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                            "image", editViewModel.existingphotopath);
                        System.IO.File.Delete(filePath);
                    }
                    // Save the new photo in wwwroot/images folder and update
                    // PhotoPath property of the employee object which will be
                    // eventually saved in the database
                    employee.photopath = uploadphoto(editViewModel);
                }

            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return RedirectToAction("details", new { id = id });
        }

        [HttpPost]
        public IActionResult Deleteemp (Employee employee)
        {
            Employee emp=_emprepo.DeleteEmployee(employee.id);
            return View();
        }
    }
}
