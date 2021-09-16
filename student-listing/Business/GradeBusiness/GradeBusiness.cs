using student_listing.Data.DAL.GradeDataAccess;
using student_listing.Data.DAL.RegistrationDataAccess;
using student_listing.Data.DAL.StudentDataAccess;
using student_listing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Business.GradeBusiness
{
    public class GradeBusiness : IGradeBusiness
    {
        /// <summary>
        /// DAL Layer for student data
        /// </summary>
        private readonly IGradeDataAccess _gradeDataAccess;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="studentDataAccess"></param>
        public GradeBusiness(IGradeDataAccess gradeDataAccess)
        {
            _gradeDataAccess = gradeDataAccess;
        }

        /// <summary>
        /// Returns a list of all grades
        /// </summary>
        /// <returns>List of grades</returns>
        public Task<IEnumerable<Grade>> GetGrades()
        {
            return _gradeDataAccess.GetGrades();
        }
    }
}
