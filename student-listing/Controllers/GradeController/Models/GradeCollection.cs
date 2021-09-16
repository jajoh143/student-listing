using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Controllers.GradeController.Models
{
    /// <summary>
    /// GradeCollection
    /// </summary>
    public class GradeCollection : List<GradeItem>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="size"></param>
        public GradeCollection(int size) : base(size) { }

        /// <summary>
        /// Ctor
        /// </summary>
        public GradeCollection() { }
    }
}
