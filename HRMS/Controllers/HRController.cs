using HRMS.Data;
using HRMS.Migrations;
using HRMS.Models;
using HRMS.Notification;
using HRMS.Notification.Enum;
using HRMS.WithoutUI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;


namespace HRMS.Controllers
{
    [Authorize]
    public class HRController : Controller
    {
        private readonly ApplicationDbContext _db;
        public Master.GenderCRUD GC;
        public Master.DesignationCRUD DO;
        public Master.VacanciesCRUD VC;

        public HRController(ApplicationDbContext db)
        {
            _db = db;
            GC = new Master.GenderCRUD(_db);
            DO = new Master.DesignationCRUD(_db);
            VC = new Master.VacanciesCRUD(_db);
    }

        public IActionResult GenderSave()
        {
            GetData();
            ViewBag.ButtonType = "SAVE";
            ViewBag.gn = GC.GetAllGenderData();
            return View();
        }

        // POST: /HR/GenderSaveDetails
        [HttpPost]
        public IActionResult GenderSaveDetails(Gender gn)
        {
            if (gn.Pk_GenderId == 0)
            {
                bool IsSave = GC.Save(gn);
                if (IsSave)
                    TempData["Notification"] = CommonNotification.ShowAlert(Alerts.Success, "Data Insert Successfully ");
                else
                    TempData["Notification"] = CommonNotification.ShowAlert(Alerts.Error, "Something Went Wrong ");
                return RedirectToAction("GenderSave");
            }
            else
            {
                bool IsUpdate = GC.Update(gn);
                if (IsUpdate)
                    TempData["Notification"] = CommonNotification.ShowAlert(Alerts.Success, "Data Updated Successfully ");
                else
                    TempData["Notification"] = CommonNotification.ShowAlert(Alerts.Error, "Something Went Wrong ");
                return RedirectToAction("GenderSave");
            }
        }


        // GET: HR/Edit/5
        public IActionResult Edit(int id)
        {
            ViewBag.ButtonType = "UPDATE";
            ViewBag.gn = GC.GetAllGenderData();
            Gender genderedit = GC.Edit(id);
            if (genderedit != null)
            {
                return View("GenderSave", genderedit);
            }
            else
            {
                return View("GenderSave");
            }
        }

        // POST: HR/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            bool IsDelete = GC.Delete(id);
            if (IsDelete)
                TempData["Notification"] = CommonNotification.ShowAlert(Alerts.Success, "Record deleted successfully.");
            else
                TempData["Notification"] = CommonNotification.ShowAlert(Alerts.Error, "Failed to delete designation.");

            return RedirectToAction("GenderSave");
        }

        // GET: HR/CreateDesignation
        public IActionResult CreateDesignation()
        {
            ViewBag.ButtonType = "SAVE";
            ViewBag.list = DO.GetAllDesignationData();
            return View();
        }

        // POST: HR/DesignationSave
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DesignationSave(Designation designation)
        {
            //if (ModelState.IsValid)
            //{
                if (designation.PK_DesignationId == 0 || designation.PK_DesignationId == null)
                {
                    bool IsSave = DO.Save(designation);
                    if (IsSave)
                        TempData["Notification"] = CommonNotification.ShowAlert(Alerts.Success, "Data Inserted Successfully ");
                    else
                        TempData["Notification"] = CommonNotification.ShowAlert(Alerts.Error, "Something Went Wrong ");
                }
                else
                {
                    bool IsUpdate = DO.Update(designation);
                    if (IsUpdate)
                        TempData["Notification"] = CommonNotification.ShowAlert(Alerts.Success, "Data Updated Successfully ");
                    else
                        TempData["Notification"] = CommonNotification.ShowAlert(Alerts.Error, "Something Went Wrong ");
                }

                return RedirectToAction("CreateDesignation");
            }
            //else
            //{
            //    ViewBag.ButtonType = "SAVE";
            //    ViewBag.list = DO.GetAllDesignationData();
            //    return View("CreateDesignation");
            //}
        

        // GET: HR/EditDesignation/5
        public IActionResult EditDesignation(int id)
        {
            ViewBag.ButtonType = "UPDATE";
            ViewBag.list = DO.GetAllDesignationData();
            Designation designationEdit = DO.Edit(id);
            if (designationEdit != null)
            {
                return View("CreateDesignation", designationEdit);
            }
            else
            {
                return View("CreateDesignation");
            }
        }

        // POST: HR/DeleteDesignation/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            bool IsDelete = DO.Delete(id);
            if (IsDelete)
                TempData["Notification"] = CommonNotification.ShowAlert(Alerts.Success, "Designation deleted successfully.");
            else
                TempData["Notification"] = CommonNotification.ShowAlert(Alerts.Error, "Failed to delete designation.");

            return RedirectToAction("CreateDesignation");
        }



















        public IActionResult Vacancies()
        {
            GetData();
            ViewBag.ButtonText = "SAVE";
            GetDD(0, 0);
            return View();
        }

        public void GetDD(int? DegID, int? ExpId)
        {
            List<Designation> _designations = VC.GetDesignationList();
            ViewBag.DesignationList = new SelectList(_designations, "PK_DesignationId", "DesignationName", DegID);
            List<Experience> experiences = VC.GetExpressions();
            ViewBag.ExperienceList = new SelectList(experiences, "Id", "RequiredExperience", ExpId);
        }

        public IActionResult VacanciesSaveUpdate(Vacancies vacancies)
        {
            if (ModelState.IsValid)
            {
                bool isSaveSuccessful = VC.Save(vacancies);

                if (isSaveSuccessful)
                {
                    TempData["Notification"] = CommonNotification.ShowAlert(Alerts.Success, "Data saved successfully.");
                }
                else
                {
                    TempData["Notification"] = CommonNotification.ShowAlert(Alerts.Error, "Something went wrong.");
                }

                return RedirectToAction("Vacancies");
            }
            else
            {
                ViewBag.ButtonText = "SAVE";
                int DegId = Convert.ToInt32(vacancies.Fk_DesignationId);
                int ExpId = Convert.ToInt32(vacancies.Fk_ExperienceId);
                GetDD(DegId, ExpId);
                return View("Vacancies");  // Return the same model back to the view
            }
        }

        public IActionResult EditVacancy(int id)
        {
            var vacancy = VC.Edit(id);
            if (vacancy != null)
            {
                ViewBag.ButtonText = "UPDATE";
                GetDD(vacancy.Fk_DesignationId, vacancy.Fk_ExperienceId);
                return View("Vacancies", vacancy);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteVacancy(int id)
        {
            bool isDeleteSuccessful = VC.Delete(id);

            if (isDeleteSuccessful)
            {
                TempData["Notification"] = CommonNotification.ShowAlert(Alerts.Success, "Data deleted successfully.");
            }
            else
            {
                TempData["Notification"] = CommonNotification.ShowAlert(Alerts.Error, "Something went wrong.");
            }

            return RedirectToAction("Vacancies");
        }

        public void GetData()
        {
            ViewBag.VacanciesList = VC.GetAllDataVacancies();
        }
    }

}
