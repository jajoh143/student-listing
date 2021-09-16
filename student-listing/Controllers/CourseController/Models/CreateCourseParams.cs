namespace student_listing.Controllers.CourseController.Models
{
    /// <summary>
    /// CreateCourseParams
    /// </summary>
    public class CreateCourseParams
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// CreditHours
        /// </summary>
        public int CreditHours { get; set; }
    }
}
