using student_listing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Business.CourseBusiness
{
    public interface ICourseBusiness
    {
        /// <summary>
        /// GetStudentList
        /// </summary>
        /// <returns>Returns a list of all students</returns>
        Task<IEnumerable<Course>> GetCourseList();
    }
}
