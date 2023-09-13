using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Position
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string PositionName { get; set; }
    }
}
