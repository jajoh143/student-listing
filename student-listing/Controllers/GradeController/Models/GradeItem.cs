using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Controllers.GradeController.Models
{
    /// <summary>
    /// GradeItem
    /// </summary>
    public class GradeItem
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
