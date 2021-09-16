using System.Runtime.Serialization;

namespace student_listing.Web.Controllers.StudentController.Models
{
    /// <summary>
    /// RegistrationItem
    /// </summary>
    public class RegistrationItem
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Course Id
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Course Name
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// Course Hours
        /// </summary>
        public int CourseHours { get; set; }

        /// <summary>
        /// Grade Score
        /// </summary>
        public string GradeLetter { get; set; }
    }
}
