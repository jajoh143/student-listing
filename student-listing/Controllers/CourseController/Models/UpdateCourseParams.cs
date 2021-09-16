namespace student_listing.Controllers.CourseController
{
    /// <summary>
    /// Update Course Params
    /// </summary>
    public class UpdateCourseParams
    {
        /// <summary>
        /// CourseId
        /// </summary>
        public int CourseId { get; set; }

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