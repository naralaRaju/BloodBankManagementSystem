using BBMS1.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBMS1.Controllers
{
    public class LoginController : Controller
    {
        private ApplicationDbContext _dbContext;
        
        public LoginController()
        {
            _dbContext = new ApplicationDbContext();
            
        }
        // GET: Login
        
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Create()
        {
            TempData["SuccessMessage"] = "Patient deleted successfully.";
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserModel1 user)
        {
            UserModel1 dbUser = _dbContext.UserModelOnes.SingleOrDefault(u => u.UserName == user.UserName);
            
            if (dbUser != null && dbUser.Password==user.Password)
            {
                
                return RedirectToAction("UserDashboard", "Login");
            }

            else
                {
                    ViewBag.ErrorMessage = "Incorrect Details";
                    ModelState.AddModelError("", "Invalid Details");
                    return View("Login");
                }
            }
       
        public ActionResult UserDashboard()
        {
            return View();

        }
        public ActionResult Donor()
        {
            return View();
        }
        public ActionResult Save(Donors userModel1)
        {
            _dbContext.DonorsList.Add(userModel1);
            _dbContext.SaveChanges();
            TempData["SuccessMessage"] = "Donor data Added successfully.";
            return RedirectToAction("Donors", "Login");

        }
        public ActionResult Donors()
        {
            return View(_dbContext.DonorsList.ToList());
        }
        public ActionResult Patient()
        {
            return View();
        }
        public ActionResult Enter(Patients userModel1)
        {
            _dbContext.PatientsList.Add(userModel1);
            _dbContext.SaveChanges();
            TempData["SuccessMessage"] = "Patient data Added successfully.";
            return RedirectToAction("Patients", "Login");

        }
        public ActionResult Patients()
        {
            return View(_dbContext.PatientsList.ToList());
        }
        private static List<Donors> users = new List<Donors>();
        public ActionResult EditDonor(int id)
        {
            Donors employee = _dbContext.DonorsList.Single(u => u.Id == id);

            return View(employee);

        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult SaveChanges(Donors employee)
        {
            //if (ModelState.IsValid)
            //{
            if (employee.Id == 0)
            {
                int newId = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
                employee.Id = newId;
                _dbContext.DonorsList.Add(employee);
                TempData["SuccessMessage"] = "Donor added sucessfully.";
            }
            else
            {
                Donors existingEmployee = _dbContext.DonorsList.Single(u => u.Id == employee.Id);
                //var existingEmployee= _dbContext.UserModelOnes.Single(u=>u.Id==employee.Id);
                if (existingEmployee != null)
                {
                    existingEmployee.Name = employee.Name;
                    existingEmployee.Age = employee.Age;
                    existingEmployee.Phone = employee.Phone;
                    existingEmployee.Gender = employee.Gender;
                    existingEmployee.BloodGroup = employee.BloodGroup;
                    existingEmployee.Address = employee.Address;
                    TempData["SuccessMessage"] = "Donor  data updated successfully.";

                }

            }
            _dbContext.SaveChanges();
            return RedirectToAction("Donors", "Login");
            //}
            //return RedirectToAction("Employee", "AdminDashboard");
        }
        public ActionResult DeleteDonor(int id)
        {
            Donors employee = _dbContext.DonorsList.Single(u => u.Id == id);
            return View(employee);
        }
        public ActionResult Delete(int id)
        {
            Donors employee = _dbContext.DonorsList.Single(u => u.Id == id);
            if (employee != null)
            {
                _dbContext.DonorsList.Remove(employee);
                TempData["SuccessMessage"] = "Donor data deleted successfully.";

            }
            _dbContext.SaveChanges();
            return RedirectToAction("Donors","Login");
        }
        private static List<Patients> user = new List<Patients>();
        public ActionResult EditPatient(int id)
        {
            Patients patient = _dbContext.PatientsList.Single(u => u.Id == id);

            return View(patient);

        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult SaveChange(Patients patient)
        {
            //if (ModelState.IsValid)
            //{
            if (patient.Id == 0)
            {
                int newId = user.Count > 0 ? user.Max(u => u.Id) + 1 : 1;
                patient.Id = newId;
                _dbContext.PatientsList.Add(patient);
                TempData["SuccessMessage"] = "Patient added sucessfully.";
            }
            else
            {
                Patients existingPatient = _dbContext.PatientsList.Single(u => u.Id == patient.Id);
                //var existingEmployee= _dbContext.UserModelOnes.Single(u=>u.Id==employee.Id);
                if (existingPatient != null)
                {
                    existingPatient.Name = patient.Name;
                    existingPatient.Age = patient.Age;
                    existingPatient.PhoneNo = patient.PhoneNo;
                    existingPatient.Gender = patient.Gender;
                    existingPatient.BloodGroup = patient.BloodGroup;
                    existingPatient.Address = patient.Address;
                    TempData["SuccessMessage"] = "Patient data  updated successfully.";

                }

            }
            _dbContext.SaveChanges();
            return RedirectToAction("Patients", "Login");
            //}
            //return RedirectToAction("Employee", "AdminDashboard");
        }
        public ActionResult DeletePatient(int id)
        {
            Patients patient = _dbContext.PatientsList.Single(u => u.Id == id);
            return View(patient);
        }
        public ActionResult Remove(int id)
        {
            Patients patient = _dbContext.PatientsList.Single(u => u.Id == id);
            if (patient != null)
            {
                _dbContext.PatientsList.Remove(patient);
                TempData["SuccessMessage"] = "Patient deleted successfully.";

            }
            _dbContext.SaveChanges();
            return RedirectToAction("Patients", "Login");
        }
        public ActionResult Donation(int id)
        {
            Donors donation = _dbContext.DonorsList.Single(u => u.Id == id);
            return View(donation);
        }
        public ActionResult Transfer(int id)
        {
            Patients transfer = _dbContext.PatientsList.Single(u => u.Id == id);
            return View(transfer);
        }
        //public ActionResult Donate(int id)
        //{
        //    Donors donoation = _dbContext.PatientsList.Single(u => u.Id == id);
        //    if (patient != null)
        //    {
        //        _dbContext.PatientsList.Remove(patient);
        //        TempData["SuccessMessage"] = "Employee deleted successfully.";

        //    }
        //    _dbContext.SaveChanges();
        //    return RedirectToAction("Patients", "Login");
        //    }

    }

}