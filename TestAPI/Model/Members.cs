using System.ComponentModel.DataAnnotations;

namespace TestAPI.Model
{
    public class Members
    {
        [Key]
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
