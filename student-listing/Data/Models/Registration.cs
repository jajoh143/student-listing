namespace student_listing.Data.Models
{
    /// <summary>
    /// Registration
    /// </summary>
    public class Registration
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Student Id
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Student - The student associated with the registration (Entity Framework)
        /// </summary>
        public Student Student { get; set; }

        /// <summary>
        /// Course Id
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Course - The course associated with the registration (Entity Framework)
        /// </summary>
        public Course Course { get; set; }

        /// <summary>
        /// Grade Id
        /// </summary>
        public int GradeId { get; set; }

        /// <summary>
        /// Grade - The grade associated with the registraton (Entity Framework)
        /// </summary>
        public Grade Grade { get; set; }
    }
}
