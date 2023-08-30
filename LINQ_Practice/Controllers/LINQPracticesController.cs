using LINQ_Practice.Models;
using Microsoft.AspNetCore.Mvc;

namespace LINQ_Practice.Controllers
{
    public class LINQPracticesController : Controller
    {
        private DB2023_LINQContext dBContext { get; set; }

        [BindProperty]
        public TblEmployee employee { get; set; }

        public LINQPracticesController(DB2023_LINQContext _DBContext)
        {
            this.dBContext = _DBContext;
        }
        public IActionResult getRecords()
        {
            //List<TblEmployee> emp = (from e in this.dBContext.TblEmployees
            //                         select e).ToList();
            List<TblEmployee> emp = (from e in this.dBContext.TblEmployees
                                     where e.Gender == "Female"
                                     orderby e.Salary descending
                                     select e).ToList();

            var emp2 = from e in dBContext.TblEmployees
                       where e.Id==1
                       select e;

            //We have to define that what kind of method we are expecting
            var empMethod = dBContext.TblEmployees.AsQueryable().Where(x => x.Gender == "Female");

            //var empMix = (from e in dBContext.TblEmployees
            //              select e).AsQueryable().Max();

            //var selectmanyemp=dBContext.TblEmployees.Select(x=>x.DepartmentNavigation.DepartmentName);
            return View(empMethod);


            //return View(emp);
            //return View(empMethod);
            //return View(empMix);
        }

        public IActionResult createRecords()
        {
            return View();
        }

        [HttpPost]
        [ActionName("createRecords")]
        public IActionResult InsertRecords()
        {
            if (ModelState.IsValid)
            {
                dBContext.Add(employee);
                dBContext.SaveChanges();
            }
            return RedirectToAction("getRecords");
        }
    }
}
