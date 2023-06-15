using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;



namespace NanditaP3.Controllers
{
    public class EmployeeController : Controller
    {
       
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees=employeeBusinessLayer.GetAllEmployees().ToList();

            return View(employees);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }


        [HttpGet]
     
        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            //Employee employee=employeeBusinessLayer.GetAllEmployees().Single(emp=> emp.Id == id);
            Employee employee = employeeBusinessLayer.GetAllEmployees().Single(emp => emp.Id == id);

            return View(employee);
        }





        [HttpPost]
        
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid) {
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.SaveEmployee(employee);

                return RedirectToAction("Index");
            }
            return View(employee);
        }





        //Instead of passing "Employee" object as parameters to "create_Post()" action method,we are creating an instance of an "Employee"
        //object with in the function,and updating it using "UpdateModel()" function.

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {

          
            if (ModelState.IsValid)
             {
                 Employee employee = new Employee();
                 TryUpdateModel(employee);

                 EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                 employeeBusinessLayer.AddEmployee(employee);

                 return RedirectToAction("Index");

             }
            return View();
            /*Employee employee = new Employee();
            employee.Name =name;
            employee.City = city;
            employee.DateOfBirth =dateOfBirth;
            */



            /*foreach(string key in formCollection.AllKeys)
          {
              

              
          Response.Write("Key=" + key + " ");
              Response.Write(formCollection[key]);
              Response.Write("</br>");
             

        } */






        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
       



    }
}