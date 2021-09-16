﻿using System.Collections.Generic;
using System.Threading.Tasks;
using student_listing.Models;

namespace student_listing.Business.StudentBusiness
{
    public interface IStudentBusiness
    {
        /// <summary>
        /// GetStudentList
        /// </summary>
        /// <returns>Returns a list of all students</returns>
        Task<IEnumerable<Student>> GetStudentList();

        /// <summary>
        /// GetStudent
        /// </summary>
        /// <param name="id">student id</param>
        /// <returns>Student object</returns>
        Task<Student> GetStudent(int id);

        /// <summary>
        /// UpdateStudent - update a student
        /// </summary>
        /// <param name="student">student</param>
        /// <returns>whether or not the student was successfully updated</returns>
        Task<bool> UpdateStudent(Student student);

        /// <summary>
        /// Create Student - create a student
        /// </summary>
        /// <param name="student">student</param>
        /// <returns>Whether or not the student was created</returns>
        Task<bool> CreateStudent(Student student);
    }
}
