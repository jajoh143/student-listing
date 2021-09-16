namespace student_listing.Controllers.StudentController.Models
{
    /// <summary>
    /// Create Student Result
    /// </summary>
    public class CreateStudentResult
    {
        /// <summary>
        /// Success - Whether the student was created successfully or not
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="success"></param>
        public CreateStudentResult(bool success)
        {
            Success = success;
        }
    }
}
