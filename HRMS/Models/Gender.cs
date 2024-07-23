using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Gender
    {
        [Key]
        public int Pk_GenderId { get; set; }
        [Required(ErrorMessage = "Gendername is Required!!")]
        public string GenderName { get; set; }
        public char Alias { get; set; }
        public bool isActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
