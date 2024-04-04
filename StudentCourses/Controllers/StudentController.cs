using Microsoft.AspNetCore.Mvc;
using StudentCourses.Models;
using StudentCourses.Services;

namespace REST_API_TEMPLATE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ICoursesServices _coursesService;

        public StudentController(ICoursesServices coursesService)
        {
            _coursesService = coursesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetIdStudent()
        {
            var authors = await _coursesService.getAllStudent();

            if (authors == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No authors in database");
            }

            return StatusCode(StatusCodes.Status200OK, authors);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetIdStudent(Guid id, bool includeCourses = false)
        {
            Student student = await _coursesService.GetIdStudent(id, includeCourses);

            if (student == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Author found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, student);
        }

        [HttpPost]
        public async Task<ActionResult<Courses>> AddStudent(Student student)
        {
            var dbCourses = await _coursesService.AddStudent(student);

            if (dbCourses == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{student.Name} could not be added.");
            }

            return CreatedAtAction("GetIdStudent", new { id = student.StudentId }, student);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateStudent(Guid id, Student student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            Student dbCourses = await _coursesService.UpdateStudent(student);

            if (dbCourses == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{student.Name} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var courses = await _coursesService.GetIdStudent(id, false);
            (bool status, string message) = await _coursesService.DeleteStudent(courses);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, courses);
        }
    }
}