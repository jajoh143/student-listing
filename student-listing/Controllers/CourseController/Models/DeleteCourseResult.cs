namespace student_listing.Controllers.CourseController.Models
{
    /// <summary>
    /// DeleteCourseResult
    /// </summary>
    public class DeleteCourseResult
    {
        /// <summary>
        /// Success - Whether the course was deleted successfully
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="success">if the course was deleted</param>
        public DeleteCourseResult(bool success)
        {
            Success = success;
        }
    }
}
