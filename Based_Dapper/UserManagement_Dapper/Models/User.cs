using System.ComponentModel.DataAnnotations;

namespace UserManagement_Dapper.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="User name")]
        public string? UserName { get; set; }
        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }
    }
}
