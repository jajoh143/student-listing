namespace student_listing.Models
{
    /// <summary>
    /// Grade
    /// </summary>
    public class Grade
    {
        /// <summary>
        /// Grade Id
        /// </summary>
        public int GradeId { get; set; }

        /// <summary>
        /// Grade Score, used for grade calculations
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Grade Letter Display
        /// </summary>
        public string Letter { get; set; }
    }
}
