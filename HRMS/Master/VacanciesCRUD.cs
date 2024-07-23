using HRMS.Data;
using HRMS.Models;
using HRMS.WithoutUI;

namespace HRMS.Master
{
    public class VacanciesCRUD
    {
        private readonly ApplicationDbContext _db;
        public VacanciesCRUD(ApplicationDbContext db)
        {
            this._db = db;
        }

        public bool Save(Vacancies vacancies)
        {
            if (vacancies.Pk_VacanciesID == null || vacancies.Pk_VacanciesID == 0)
            {
                vacancies.CreatedOn = DateTime.Now;
                _db.Comm_Vacancies.Add(vacancies);
            }
            else
            {
                var existingVacancies = _db.Comm_Vacancies.Find(vacancies.Pk_VacanciesID);
                if (existingVacancies != null)
                {
                    existingVacancies.Fk_DesignationId = vacancies.Fk_DesignationId;
                    existingVacancies.Fk_ExperienceId = vacancies.Fk_ExperienceId;
                    existingVacancies.TotalPost = vacancies.TotalPost;
                    existingVacancies.Remarks = vacancies.Remarks;
                    existingVacancies.Technology = vacancies.Technology;
                    existingVacancies.IsActive = vacancies.IsActive;
                    _db.Comm_Vacancies.Update(existingVacancies);
                }
            }

            return _db.SaveChanges() > 0;
        }

        public bool Update(Vacancies vacancies)
        {
            if (vacancies.Pk_VacanciesID != null && vacancies.Pk_VacanciesID != 0)
            {
                var existingVacancies = _db.Comm_Vacancies.Find(vacancies.Pk_VacanciesID);
                if (existingVacancies != null)
                {
                    existingVacancies.Fk_DesignationId = vacancies.Fk_DesignationId;
                    existingVacancies.Fk_ExperienceId = vacancies.Fk_ExperienceId;
                    existingVacancies.TotalPost = vacancies.TotalPost;
                    existingVacancies.Remarks = vacancies.Remarks;
                    existingVacancies.Technology = vacancies.Technology;
                    existingVacancies.IsActive = vacancies.IsActive;
                    _db.Comm_Vacancies.Update(existingVacancies);
                    return _db.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool Delete(int id)
        {
            var vacancy = _db.Comm_Vacancies.Find(id);
            if (vacancy != null)
            {
                _db.Comm_Vacancies.Remove(vacancy);
                return _db.SaveChanges() > 0;
            }
            return false;
        }

        public Vacancies Edit(int id)
        {
            return _db.Comm_Vacancies.Find(id);
        }

        public List<Designation> GetDesignationList()
        {
            List<Designation> designations = _db.Designations.ToList();
            designations.Insert(0, new Designation { PK_DesignationId = 0, DesignationName = "--Please Select Designation--" });
            return designations;
        }

        public List<Experience> GetExpressions()
        {
            List<Experience> experiences = _db.Experiences.ToList();
            experiences.Insert(0, new Experience { Id = 0, RequiredExperience = "--Please Select Experience--" });
            return experiences;
        }

        public IEnumerable<dynamic> GetAllDataVacancies()
        {
            List<Vacancies> _vacancies = _db.Comm_Vacancies.ToList();
            List<Designation> _designations = _db.Designations.ToList();
            List<Experience> _experience = _db.Experiences.ToList();

            IEnumerable<dynamic> AllData = (from vacancies in _vacancies
                                            join designations in _designations on vacancies.Fk_DesignationId equals designations.PK_DesignationId
                                            join experience in _experience on vacancies.Fk_ExperienceId equals experience.Id
                                            select new
                                            {
                                                Pk_VacanciesID = vacancies.Pk_VacanciesID,
                                                DesignationName = designations.DesignationName,
                                                Experience = experience.RequiredExperience,
                                                TotalPost = vacancies.TotalPost,
                                                Remarks = vacancies.Remarks,
                                                Technology = vacancies.Technology,
                                                IsActive = vacancies.IsActive,
                                                Pk_DesignationId = designations.PK_DesignationId
                                            }).ToList();
            return AllData;
        }
    }
}
