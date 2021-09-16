using System.Collections.Generic;
using System.Runtime.Serialization;

namespace student_listing.Web.Controllers.CourseController.Models
{
    /// <summary>
    /// CourseCollection
    /// </summary>
    [CollectionDataContract(Name = "courseCollection", ItemName = "courseItem")]
    public class CourseCollection : List<CourseItem>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="size"></param>
        public CourseCollection(int size) : base(size) { }

        /// <summary>
        /// Ctor
        /// </summary>
        public CourseCollection() { }
    }
}
