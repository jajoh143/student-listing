namespace student_listing.Controllers.CourseController
{
    /// <summary>
    /// Update Course Result
    /// </summary>
    public class UpdateCourseResult
    {
        /// <summary>
        /// Success - Whether or not the course was successfully updated
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="success">Whether or not the course was successfully created</param>
        public UpdateCourseResult(bool success)
        {
            Success = success;
        }
    }
}