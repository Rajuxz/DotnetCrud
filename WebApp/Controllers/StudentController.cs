using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.Models.Domain;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext _context;
        public StudentController(StudentDbContext context)
        {
            _context = context;
        }

        //Another Approach
        //public StudentController()
        //{
        //    _context = HttpContext.RequestServices.GetService(typeof(StudentDbContext)) as StudentDbContext;
        //}
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(StudentViewModel studentVM)
        {
            var student = new StudentModel()
            {
                Name = studentVM.Name,
                Address = studentVM.Address,
                Email = studentVM.Email,
                Phone = studentVM.Phone,

            };

            _context.StudentTable.Add(student); //Adding data to databse
            _context.SaveChanges();
            return RedirectToAction("ViewStudent");
        }

        [HttpGet]
        public IActionResult ViewStudent() {
            var student = _context.StudentTable.ToList();
            return View(student);
        }
        public IActionResult UpdateStudent(int id)
        {
            var studentData = _context.StudentTable.FirstOrDefault(x => x.Id == id);
            if(studentData!= null)
            {
                var student = new UpdateStudentViewModel()
                {
                    Id = studentData.Id,
                    Name = studentData.Name,
                    Address = studentData.Address,
                    Email = studentData.Email,
                    Phone = studentData.Phone,
                };
                return View(student);
            }

            return RedirectToAction("ViewStudent");
        }
        [HttpPost]
        public IActionResult UpdateStudent(UpdateStudentViewModel updateViewModel)
        {
            var student = _context.StudentTable.Find(updateViewModel.Id);
            //check if there exist data with the given id or not

            if (student != null)
            {
                student.Name = updateViewModel.Name;
                student.Address = updateViewModel.Address;
                student.Email = updateViewModel.Email;
                student.Phone = updateViewModel.Phone;
                _context.SaveChanges();
                return RedirectToAction("ViewStudent");
            }
            //Else is the case of 404 student not found :D
            return RedirectToAction("Error404NotFound");
        }
        public IActionResult DeleteStudent(int Id)
        {
            var student = _context.StudentTable.Find(Id);
            if(student != null) {
                _context.StudentTable.Remove(student);
                _context.SaveChanges();
                return RedirectToAction("ViewStudent");
            }
            return RedirectToAction("Error404NotFound");
        }
        public IActionResult Error404NotFound()
        {
            return View();
        }
        
    }
}
