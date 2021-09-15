namespace student_listing.Models
{
    /// <summary>
    /// Course
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Id
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
