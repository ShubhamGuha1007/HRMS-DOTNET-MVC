using HRMS.Data;
using HRMS.Models;

namespace HRMS.Master
{
    public class GenderCRUD
    {
        private readonly ApplicationDbContext _db;
        public GenderCRUD(ApplicationDbContext db)
        {
            this._db = db;
        }

        public bool Save(Gender gender)
        {
            if (gender.Pk_GenderId == 0)
            {
                if (gender.GenderName == null)
                {
                    return false;
                }

                gender.CreatedOn = DateTime.Now;
                _db.Genders.Add(gender);
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

        public bool Update(Gender gn)
        {
            if (gn.Pk_GenderId != 0)
            {
                Gender? gen = _db.Genders.Find(gn.Pk_GenderId);
                var date = gen.CreatedOn;
                gen.GenderName = gn.GenderName;
                gen.isActive = gn.isActive;
                gen.Alias = gn.Alias;
                _db.Genders.Update(gen);
                if (_db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false ;
        }
        public List<Gender> GetAllGenderData()
        {
            var gen = _db.Genders.ToList();
            return gen;
        }
        
        public Gender Edit(int id)
        {

            Gender? genderedit = _db.Genders.Find(id);
            if (genderedit != null)
            {
                return genderedit;
            }
            else
            {
                return genderedit;
            }
        }


        public bool Delete(int id)
        {
            Gender? gen = _db.Genders.Find(id);
            if (gen != null)
            {
                _db.Genders.Remove(gen);
                if (_db.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }



    }
}
