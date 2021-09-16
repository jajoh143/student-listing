﻿using System.Collections.Generic;
using System.Threading.Tasks;
using student_listing.Models;

namespace student_listing.Data.DAL.StudentDataAccess
{
    public interface IStudentDataAccess
    {
        /// <summary>
        /// Retrieves a list of all students from the database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Student>> GetStudents();

        /// <summary>
        /// Retrieves a student from the database
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>The student object</returns>
        Task<Student> GetStudent(int id);
    }
}
