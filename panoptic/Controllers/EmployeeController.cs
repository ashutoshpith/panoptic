using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using panoptic.Models;

namespace panoptic.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();

        public IActionResult Index()
        {
            List<Employee> lstemployee = new List<Employee>();
            lstemployee = objemployee.GetAllEmployees().ToList();

            return View(lstemployee);
        }
    }
}
