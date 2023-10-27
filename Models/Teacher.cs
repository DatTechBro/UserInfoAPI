using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserInfoAPI.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string? NationalIDNumber { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Surname { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string? TeacherNumber { get; set; }
        [Column("Salary")]
        public decimal Salary { get; set; }
    }
}
