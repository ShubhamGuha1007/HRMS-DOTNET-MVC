using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Designation
    {
    [Key]
    public int PK_DesignationId { get; set; }
    [Required(ErrorMessage ="Designation is Required!!")]
    public string DesignationName { get; set; }
    [Required]
    public string JobType { get; set; }
    public bool IsActive {  get; set; }
    [Required]
    public string Location { get; set; }
    public DateTime CreatedOn { get; set; }
    }
}
