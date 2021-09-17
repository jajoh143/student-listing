namespace student_listing.Controllers.StudentController
{
    /// <summary>
    /// DeleteStudentResult
    /// </summary>
    public class DeleteStudentResult
    {
        /// <summary>
        /// Success
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="success">success</param>
        public DeleteStudentResult(bool success)
        {
            Success = success;
        }
    }
}