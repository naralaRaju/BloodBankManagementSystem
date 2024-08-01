using BBMS1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBMS1.Controllers
{
    
    public class BloodStockController : Controller
    {
        // GET: BloodStock
        private readonly ApplicationDbContext _dbContext;
        public BloodStockController()
        {
            _dbContext = new ApplicationDbContext();

        }
        public ActionResult BloodStock()
        {
            var bloodStock = _dbContext.BloodStocks.ToList();
            return View(bloodStock);
        }
        [HttpPost]
        public ActionResult Donate(int Id)
            
        {
            Donors donor=_dbContext.DonorsList.Find(Id);
            var bloodStock = _dbContext.BloodStocks.FirstOrDefault(bs => bs.BloodType == donor.BloodGroup);
            if (bloodStock != null)
            {
                bloodStock.PacketCount++;
                _dbContext.SaveChanges();
                TempData["SuccessMessage"] = "Donated blood";
            }
            else
            {
                bloodStock = new BloodStock { BloodType = donor.BloodGroup, PacketCount = 1 };
                _dbContext.BloodStocks.Add(bloodStock);
                TempData["SuccessMessage"] = "Donated blood";
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Donors", "Login");
        }
        [HttpPost]
        public ActionResult Transfer(int Id)

        {
            Patients patient = _dbContext.PatientsList.Find(Id);
            var bloodStock = _dbContext.BloodStocks.FirstOrDefault(bs => bs.BloodType == patient.BloodGroup);
            if (bloodStock != null)
            {
                if (bloodStock.PacketCount > 0) 
                { 
                  bloodStock.PacketCount--;
                  _dbContext.SaveChanges();
                  TempData["SuccessMessage"] = "Transfered blood";
                }
                else
                {
                    TempData["SuccessMessage"] = "Required blood is not Available";
                }
            }
           
            _dbContext.SaveChanges();
            return RedirectToAction("Patients", "Login");
        }
    }
}