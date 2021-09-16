using student_listing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Controllers.GradeController.Models
{
    /// <summary>
    /// GetGradeList
    /// </summary>
    public class GetGradeList
    {
        /// <summary>
        /// List of grades
        /// </summary>
        public GradeCollection GradeCollection { get; set; }

        public GetGradeList(IEnumerable<Grade> grades)
        {
            if (grades == null) throw new ArgumentNullException(nameof(grades), "Invalid value provided");

            GradeCollection gradeCollection = new GradeCollection(grades.Count());

            foreach(Grade grade in grades)
            {
                gradeCollection.Add(new GradeItem
                {
                    GradeId = grade.GradeId,
                    Letter = grade.Letter,
                    Score = grade.Score
                });
            }

            GradeCollection = gradeCollection;
        }
    }
}
