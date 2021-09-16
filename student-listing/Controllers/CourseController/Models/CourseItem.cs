using System.Runtime.Serialization;

namespace student_listing.Web.Controllers.CourseController.Models
{
    /// <summary>
    /// CourseItem
    /// </summary>
    public class CourseItem
    {
        /// <summary>
        /// Course Id
        /// </summary>
        public int CourseId { get; set; }
        
        /// <summary>
        /// Course Name
        /// </summary>
        public string CourseName { get; set; }
        
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Credit Hours
        /// </summary>
        public int CreditHours { get; set; }
    }
}
