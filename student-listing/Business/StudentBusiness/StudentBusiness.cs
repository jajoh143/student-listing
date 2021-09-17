using student_listing.Data.DAL.RegistrationDataAccess;
using student_listing.Data.DAL.StudentDataAccess;
using student_listing.Models;
using System;
using System.Collections.Generic;
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
        public async Task<Student> GetStudent(int studentId)
        {
            if (studentId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(studentId), "Invalid student id provided");
            }

            Student student = await _studentDataAcess.GetStudent(studentId);
            IEnumerable<Registration> registrations = await _registrationDataAccess.GetRegistrationListForStudent(studentId);

            student.Registrations = registrations;
            return student;
        }

        /// <summary>
        /// Updates a student in the database
        /// </summary>
        /// <param name="student">student</param>
        /// <returns>if the student was created successfully</returns>
        public async Task<bool> UpdateStudent(Student student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student), "Invalid argument provided");
            int updateStudentRowsAffected = await _studentDataAcess.UpdateStudent(student);

            if (updateStudentRowsAffected == 1)
            {
                 return true;
            }
            return false;
        }

        /// <summary>
        /// Creates a student in the database
        /// </summary>
        /// <param name="student">student</param>
        /// <returns>If the student was created successfully</returns>
        public async Task<bool> CreateStudent(Student student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student), "Invalid argument provided");

            int createStudentRowsAffected = await _studentDataAcess.CreateStudent(student);

            if (createStudentRowsAffected == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Deletes a student
        /// </summary>
        /// <param name="studentId">student id</param>
        /// <returns>if the student was deleted correctly</returns>
        public async Task<bool> DeleteStudent(int studentId)
        {
            if (studentId <= 0) throw new ArgumentOutOfRangeException(nameof(studentId), "Invalid argument provided");

            int iRowsAffected = await _studentDataAcess.DeleteStudent(studentId);

            if (iRowsAffected == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns a list of students that match the search term
        /// </summary>
        /// <param name="searchTerm">search term</param>
        /// <returns>list of students</returns>
        public async Task<IEnumerable<Student>> SearchStudents(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) throw new ArgumentException("Invalid searchTerm provided", nameof(searchTerm));

            return await _studentDataAcess.SearchStudents(searchTerm);
        }
    }
}
