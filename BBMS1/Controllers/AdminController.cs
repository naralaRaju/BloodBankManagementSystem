using BBMS1.Models;
using BBMS1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBMS1.Controllers
{
    public class AdminController : Controller
    {
        private const string AdminPassword = "admin123";
        private ApplicationDbContext _dbContext;
        public AdminController() 
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Admin
        public ActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Admin(AdminLogin admin)
        {
                return View();
        }
        public ActionResult AdminDashboard()
        {
            return View();
        }
        public ActionResult Logout() {
            return RedirectToAction("Admin", "Admin");

        }
        //public ActionResult SignIn()
        //{
        //    return View();
        //}
        public ActionResult SignIn(AdminLogin admin)
        {
            if(admin.Password == AdminPassword)
            {
                return RedirectToAction("AdminDashboard");
            }
            else
            {
                ViewBag.ErrorMessage = "Incorrect Password";
                ModelState.AddModelError("", "Invalid password");
                return View("Admin");
            }
        }
        private static List<UserModel1> users = new List<UserModel1>();
        public ActionResult NewUser()
        {
            return View();
        }
        //public ActionResult NewUser(UserModel1 user) 
        //{
        //    if(ModelState.IsValid)
        //    {
        //        users.Add(user);
        //        return RedirectToAction("AdminDashboard");
        //    }
        //    return View(users);
        //}
        public ActionResult Employee()
        {
            return View(_dbContext.UserModelOnes.ToList());
        }
        
        public ActionResult Save(UserModel1 userModel1) 
        {
            _dbContext.UserModelOnes.Add(userModel1);
            _dbContext.SaveChanges();
            TempData["SuccessMessage"] = "Employee Added successfully.";
            return RedirectToAction("Employee","Admin");

        }
        public ActionResult EditUser(int id)
        {
            UserModel1 employee = _dbContext.UserModelOnes.Single(u=>u.Id== id);
            
                return View(employee);
            
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult SaveChanges(UserModel1 employee)
        {
            //if (ModelState.IsValid)
            //{
                if (employee.Id == 0)
                {
                    int newId=users.Count>0 ? users.Max(u=>u.Id)+1 : 1;
                    employee.Id = newId;
                    _dbContext.UserModelOnes.Add(employee);
                    TempData["SuccessMessage"] = "Employee added sucessfully.";
                }
                else
                {
                UserModel1 existingEmployee = _dbContext.UserModelOnes.Single(u => u.Id == employee.Id);
                //var existingEmployee= _dbContext.UserModelOnes.Single(u=>u.Id==employee.Id);
                    if(existingEmployee != null)
                    {
                        existingEmployee.UserName=employee.UserName;
                        existingEmployee.Password=employee.Password;
                        existingEmployee.Phone=employee.Phone;
                        existingEmployee.Email=employee.Email;
                        TempData["SuccessMessage"] = "Employee details updated successfully.";
                    _dbContext.SaveChanges();

                }
                    
                }
                        _dbContext.SaveChanges();
                return RedirectToAction("Employee","Admin");
            //}
            //return RedirectToAction("Employee", "AdminDashboard");
        }
        public ActionResult DeleteUser(int id)
        {
            UserModel1 employee = _dbContext.UserModelOnes.Single(u => u.Id == id);
            return View(employee);
        }
        public ActionResult Delete(int id)
        {
            UserModel1 employee = _dbContext.UserModelOnes.Single(u => u.Id == id);
            if(employee != null)
            {
                _dbContext.UserModelOnes.Remove(employee);
                TempData["SuccessMessage"] = "Employee deleted successfully.";

            }
            _dbContext.SaveChanges();
            return RedirectToAction("Employee", "Admin");
        }
        public ActionResult Dashboard()
        {
            DashboardViewModel model = new DashboardViewModel();
            model.PatientCount = _dbContext.PatientsList.Count();
            model.DonorCount = _dbContext.DonorsList.Count();
            model.EmployeeCount = _dbContext.UserModelOnes.Count();
            return View(model);
        }
        public ActionResult Search(string searchTerm) 
        {
            var emp = _dbContext.UserModelOnes.Where(u => u.UserName.Contains(searchTerm)).ToList();
            if(emp!=null)
            {
                return View(emp);
            }
            else
            {
                TempData["SuccessMessage"] = "Employee details updated successfully.";
                return View("Employee results", null);
            }
            
        }
       
    }
    }