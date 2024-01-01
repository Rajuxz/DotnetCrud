using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class UpdateStudentViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
