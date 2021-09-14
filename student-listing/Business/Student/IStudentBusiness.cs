using System.Collections.Generic;

namespace student_listing.Business.Student
{
    public interface IStudentBusiness
    {
        /// <summary>
        /// GetStudentList
        /// </summary>
        /// <returns>Returns a list of all students</returns>
        List<Models.Student> GetStudentList();
    }
}
