using System.ComponentModel.DataAnnotations;

namespace TestAPI.Model
{
    public class Enquery
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Desc { get; set; }
    }
}
