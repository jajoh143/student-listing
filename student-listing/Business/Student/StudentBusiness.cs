using student_listing.Data.Features;
using System.Collections.Generic;
using System.Linq;

namespace student_listing.Business.Student
{
    public class StudentBusiness : IStudentBusiness
    {
        /// <summary>
        /// DAL Layer for student data
        /// </summary>
        private readonly IStudentDataAccess _studentDataAcess;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="studentDataAccess"></param>
        public StudentBusiness(IStudentDataAccess studentDataAccess)
        {
            _studentDataAcess = studentDataAccess;
        }

        /// <summary>
        /// Gets a list of students
        /// </summary>
        /// <returns></returns>
        public List<Models.Student> GetStudentList()
        {
            List<Data.Models.Student> studentDataContext = _studentDataAcess.GetStudents();

            List<Models.Student> students = new List<Models.Student>(studentDataContext.Count);

            foreach (Data.Models.Student student in studentDataContext)
            {
                List<Models.Registration> registrations = new List<Models.Registration>();
                int cumulativeGpa = 0;

                if (student.Courses != null && student.Courses.Count > 0)
                {           
                    foreach (Data.Models.Registration registration in student.Courses)
                    {
                        registrations.Add(new Models.Registration
                        {
                            Id = registration.Id,
                            StudentId = registration.StudentId,
                            StudentFirstName = registration.Student.FirstName,
                            StudentLastName = registration.Student.LastName,
                            GradeScore = registration.Grade.Score,
                            GradeLetter = registration.Grade.Letter,
                            GradeId = registration.GradeId,
                            CourseId = registration.CourseId,
                            CourseName = registration.Course.Name,
                            CourseHours = registration.Course.CreditHours
                        });
                    }

                    cumulativeGpa = registrations.Sum(registration => registration.CourseHours * registration.GradeScore) / registrations.Sum(registration => registration.CourseHours);
                }

                students.Add(new Models.Student
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email,
                    CumulativeGpa = cumulativeGpa,
                    Registrations = registrations
                });
            }

            return students;
        }
    }
}
