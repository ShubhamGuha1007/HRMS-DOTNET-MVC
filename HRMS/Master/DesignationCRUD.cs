using HRMS.Data;
using HRMS.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS.Master
{
    public class DesignationCRUD
    {
        private readonly ApplicationDbContext _db;

        public DesignationCRUD(ApplicationDbContext db)
        {
            this._db = db;
        }

        public bool Save(Designation designation)
        {
            if (designation.PK_DesignationId == 0 || designation.PK_DesignationId == null)
            {
                designation.CreatedOn = DateTime.Now;
                _db.Designations.Add(designation);
                if (_db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool Update(Designation designation)
        {
            if (designation.PK_DesignationId != 0)
            {
                Designation? existingDesignation = _db.Designations.Find(designation.PK_DesignationId);
                if (existingDesignation != null)
                {
                    existingDesignation.DesignationName = designation.DesignationName;
                    existingDesignation.IsActive = designation.IsActive;
                    existingDesignation.JobType = designation.JobType;
                    existingDesignation.Location = designation.Location;
                    _db.Designations.Update(existingDesignation);
                    if (_db.SaveChanges() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public List<Designation> GetAllDesignationData()
        {
            var designations = _db.Designations.ToList();
            return designations;
        }

        public Designation Edit(int id)
        {
            Designation? designation = _db.Designations.Find(id);
            if (designation != null)
            {
                return designation;
            }
            else
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            Designation? designation = _db.Designations.Find(id);
            if (designation != null)
            {
                _db.Designations.Remove(designation);
                if (_db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
