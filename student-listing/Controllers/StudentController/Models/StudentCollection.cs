using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace student_listing.Web.Controllers.StudentController.Models
{
   /// <summary>
   /// StudentCollection
   /// </summary>
    public class StudentCollection : List<StudentItem>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="size"></param>
        public StudentCollection(int size) : base(size) { }

        /// <summary>
        /// Ctor
        /// </summary>
        public StudentCollection() { }
    }
}
