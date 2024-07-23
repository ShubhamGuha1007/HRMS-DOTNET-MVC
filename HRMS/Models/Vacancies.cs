using HRMS.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Data
{
    public class Vacancies
    {
        [Key]
        public int? Pk_VacanciesID { get; set; }

        [ForeignKey("Designation")]
        //[Range(1, int.MaxValue, ErrorMessage = "Please Select Validate Data..")]
        public int Fk_DesignationId { get; set; }

        public Designation? Designation { get; set; }  // Remove [Required] attribute from here if it was there

        [Required]
        public int Fk_ExperienceId { get; set; }

        [Required]
        public string TotalPost { get; set; }

        public string? Remarks { get; set; }

        [Required]
        public string Technology { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
