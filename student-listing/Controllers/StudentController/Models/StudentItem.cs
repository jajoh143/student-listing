using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace student_listing.Web.Controllers.StudentController.Models
{
    /// <summary>
    /// Student Item - for StudentCollection
    /// </summary>
    [DataContract(Name = "studentItem")]
    public class StudentItem
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember(Name = "id", Order = 0)]
        public int Id { get; set; }
        
        /// <summary>
        /// First Name
        /// </summary>
        [DataMember(Name = "firstName", Order = 0)]
        public string FirstName { get; set; }
        
        /// <summary>
        /// Last Name
        /// </summary>
        [DataMember(Name = "lastName", Order = 0)]
        public string LastName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [DataMember(Name = "email", Order = 0)]
        public string Email { get; set; }

        /// <summary>
        /// Courses - list of course names student is in
        /// </summary>
        [DataMember(Name = "courses", Order = 0)]
        public string Courses { get; set; }

        /// <summary>
        /// Cumulative GPA for student
        /// </summary>
        [DataMember(Name = "cumulativeGpa", Order = 0)]
        public decimal CumulativeGpa { get; set; }

    }
}
