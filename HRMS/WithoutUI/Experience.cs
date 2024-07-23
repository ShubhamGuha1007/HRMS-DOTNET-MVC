using System.ComponentModel.DataAnnotations;

namespace HRMS.WithoutUI
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        public string RequiredExperience { get; set; }
    }
}
