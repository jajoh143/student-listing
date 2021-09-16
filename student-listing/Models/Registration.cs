using System;
using System.Collections.Generic;
using System.Text;

namespace student_listing.Models
{
    public class Registration
    {
        /// <summary>
        /// Id
        /// </summary>
        public int RegistrationId { get; set; }

        /// <summary>
        /// Student Id
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// StudentFirstName
        /// </summary>
        public string StudentFirstName { get; set; }

        /// <summary>
        /// Student Last Name
        /// </summary>
        public string StudentLastName { get; set; }

        /// <summary>
        /// Student Name
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// Course Id
        /// </summary>
        public int CourseId { get; set; }    
        
        /// <summary>
        /// Course Name
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// Course Hours
        /// </summary>
        public int CourseHours { get; set; }

        /// <summary>
        /// Grade Id
        /// </summary>
        public int GradeId { get; set; }

        /// <summary>
        /// Grade Score
        /// </summary>
        public int GradeScore { get; set; }

        /// <summary>
        /// Grade Score
        /// </summary>
        public string GradeLetter { get; set; }

    }
}
