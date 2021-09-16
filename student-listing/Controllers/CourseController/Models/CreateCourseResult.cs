namespace student_listing.Controllers.CourseController
{
    /// <summary>
    /// CreateCourseResult
    /// </summary>
    public class CreateCourseResult
    {
        /// <summary>
        /// Success - Whether or not the course was successfully created
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="success">Whether or not the course was successfully created</param>
        public CreateCourseResult(bool success)
        {
            Success = success;
        }
    }
}