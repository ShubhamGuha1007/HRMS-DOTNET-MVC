using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Full_Forms
    {
        [Key]
        public int PK_EfId { get; set; }
        public string FullForm { get; set; }
        public string Alias { get; set; }
        public string TableName { get; set; }
    }
}