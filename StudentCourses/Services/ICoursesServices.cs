using StudentCourses.Models;

namespace StudentCourses.Services
{
    public interface ICoursesServices
    {
        //Khóa học
        Task<List<Courses>> GetAllCourses();
        Task<Courses> GetIdCourses(Guid id, bool includeCourses = false);
        Task<Courses> AddCourses(Courses courses);
        Task<Courses> UpdateCourses(Courses  courses);
        Task<(bool,string)> DeleteCourses(Courses  courses);
        //Học Sinh
        Task<List<Student>> getAllStudent();
        Task<Student> GetIdStudent(Guid id, bool includeCourses = false);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<(bool, string)> DeleteStudent(Student student);

        Task<List<Models.StudentCourses>> GetAllSCourses();
        Task<Models.StudentCourses> GetIdSCourses(Guid id);
        Task<Models.StudentCourses> AddSCourses(Models.StudentCourses sc);
        Task<Models.StudentCourses> UpdateSCourses(Models.StudentCourses sc);
        Task<(bool, string)> DeleteSCourses(Models.StudentCourses sc);
    }
}
