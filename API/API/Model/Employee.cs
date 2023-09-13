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
        public int Age { get; set; }

        [StringLength(150)]
        public string Email { get; set; }  
        public DateTime JoiningDate { get; set; }
        public string Education { get; set; }

        [StringLength(250)]
        public string Address { get; set; }
        public int Experience { get; set; }
        //public int PositionID { get; set; }

        //[NotMapped]
        //public string PositionName { get; set; }
    }
}
