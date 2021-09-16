using student_listing.Data.DAL.RegistrationDataAccess;
using student_listing.Data.DAL.StudentDataAccess;
using student_listing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Business.StudentBusiness
{
    public class StudentBusiness : IStudentBusiness
    {
        /// <summary>
        /// DAL Layer for student data
        /// </summary>
        private readonly IStudentDataAccess _studentDataAcess;

        /// <summary>
        /// DAL Layer for registration data
        /// </summary>
        private readonly IRegistrationDataAccess _registrationDataAccess;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="studentDataAccess"></param>
        public StudentBusiness(IStudentDataAccess studentDataAccess, IRegistrationDataAccess registrationDataAccess)
        {
            _studentDataAcess = studentDataAccess;
            _registrationDataAccess = registrationDataAccess;
        }

        /// <summary>
        /// Gets a list of students
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Student>> GetStudentList()
        {
            return await _studentDataAcess.GetStudents();
        }

        /// <summary>
        /// GetStudent
        /// </summary>
        /// <param name="id">student id</param>
        /// <returns>Student object</returns>
        public async Task<Student> GetStudent(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid student id provided", nameof(id));
            }

            Student student = await _studentDataAcess.GetStudent(id);
            IEnumerable<Registration> registrations = await _registrationDataAccess.GetRegistrationListForStudent(id);

            student.Registrations = registrations;
            return student;
        }
    }
}
