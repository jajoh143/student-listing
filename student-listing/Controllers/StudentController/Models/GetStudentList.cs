using student_listing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace student_listing.Web.Controllers.StudentController.Models
{
    /// <summary>
    /// GetStudentList
    /// </summary>
    public class GetStudentList
    {
        /// <summary>
        /// StudentCollection
        /// </summary>
        public StudentCollection StudentCollection{ get; set;}

        public GetStudentList(IEnumerable<Student> students)
        {
            if (students == null) throw new ArgumentNullException(nameof(students), "Invalid students object provided.");

            StudentCollection studentCollection = new StudentCollection(students.Count());

            foreach (Student student in students)
            {
                studentCollection.Add(new StudentItem
                {
                    Id = student.StudentId,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email,
                    Courses = student.CourseList,
                    CumulativeGpa = student.CumulativeGpa
                });
            }

            this.StudentCollection = studentCollection;
        }
    }
}
