using System.ComponentModel.DataAnnotations;

namespace StudentUpdate.Model
{
    public class Student
    {
        public Guid Id { get; set; }
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        [Range(18, int.MaxValue, ErrorMessage = "Age can not be less then 18.")]
        public int Age { get; set; }
    }
}
