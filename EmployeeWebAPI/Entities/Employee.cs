using System.ComponentModel.DataAnnotations;

namespace EmployeeWebAPI.Entities
{
    public class Employee
    {
        public Employee(Guid id, string fio, string jobTitle)
        {
            Id = id;
            Fio = fio;
            JobTitle = jobTitle;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Fio { get; set; }

        [Required]
        public string JobTitle { get; set; }
    }
}
