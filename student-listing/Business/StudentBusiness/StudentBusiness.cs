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
        public async Task<Student> GetStudent(int studentId)
        {
            if (studentId <= 0)
            {
                throw new ArgumentException("Invalid student id provided", nameof(studentId));
            }

            Student student = await _studentDataAcess.GetStudent(studentId);
            IEnumerable<Registration> registrations = await _registrationDataAccess.GetRegistrationListForStudent(studentId);

            student.Registrations = registrations;
            return student;
        }

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

        public async Task<bool> CreateStudent(Student student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student), "Invalid argument provided");

            int createStudentRowsAffected = await _studentDataAcess.CreateStudent(student);

            if (createStudentRowsAffected == 1)
            {
                if (student.Registrations.Count() > 0)
                {
                    int createRegistrationRowsAffected = await _registrationDataAccess.CreateRegistrations(student.Registrations);

                    if (createRegistrationRowsAffected == student.Registrations.Count())
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
