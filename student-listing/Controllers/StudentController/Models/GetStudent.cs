using student_listing.Models;
using student_listing.Web.Controllers.StudentController.Models;
using System;
using System.Linq;

namespace student_listing.Controllers.StudentController.Models
{
    public class GetStudent
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Courses
        /// </summary>
        public string CourseList { get; set; }

        /// <summary>
        /// Cumulative GPA - average of scores across registered courses for the student
        /// </summary>
        public decimal CumulativeGpa { get; set; }

        /// <summary>
        /// List of registration information for the student
        /// </summary>
        public RegistrationCollection RegistrationCollection { get; set; }

        public GetStudent(Student student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student), "Invalid student object provided.");

            RegistrationCollection registrationCollection = new RegistrationCollection();

            if (student.Registrations.Any())
            {
                foreach(Registration registration in student.Registrations)
                {
                    registrationCollection.Add(new RegistrationItem
                    {
                        Id = registration.RegistrationId,
                        CourseId = registration.CourseId,
                        CourseName = registration.CourseName,
                        CourseHours = registration.CourseHours,
                        GradeLetter = registration.GradeLetter
                    });
                }
            }

            Id = student.StudentId;
            FirstName = student.FirstName;
            LastName = student.LastName;
            Email = student.Email;
            CourseList = student.CourseList;
            CumulativeGpa = student.CumulativeGpa;
            RegistrationCollection = registrationCollection;
        }
    }
}
