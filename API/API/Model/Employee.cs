using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public  string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Age { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [Required]
        public DateTime JoiningDate { get; set; }
        
        public string Education { get; set; }

        [StringLength(100)]
        public string Designation { get; set; }

        [StringLength(250)]
        public string Address { get; set; }
        public decimal Experience { get; set; }

        [Required]
        public DateTime EndingDate { get; set; }


    }
}
