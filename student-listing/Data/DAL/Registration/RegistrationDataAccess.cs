using student_listing.Data.DataContext;
using student_listing.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace student_listing.Data.DAL
{
    public class RegistrationDataAccess : IRegistrationDataAccess
    {
        private readonly StudentListingContext _studentListingContext;

        public RegistrationDataAccess(StudentListingContext studentListingContext)
        {
            _studentListingContext = studentListingContext;
        }

        public List<student_listing.Models.Registration> GetRegistrations()
        {
            List<Registration> registrationDataContext = _studentListingContext.Registrations.ToList();

            List<student_listing.Models.Registration> registrations = new List<student_listing.Models.Registration>(registrationDataContext.Count);

            foreach(Registration registration in registrationDataContext)
            {
                registrations.Add(new student_listing.Models.Registration
                {
                    Id = registration.Id,
                    CourseId = registration.CourseId,
                    CourseName = registration.Course.Name,
                    StudentId = registration.StudentId,
                    GradeId = registration.GradeId,
                    GradeScore = registration.Grade.Score,
                    GradeLetter = registration.Grade.Letter
                });
            }

            return registrations;        
        }
    }
}
