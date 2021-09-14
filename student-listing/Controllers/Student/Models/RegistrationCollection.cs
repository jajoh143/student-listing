using System.Collections.Generic;
using System.Runtime.Serialization;
namespace student_listing.Web.Controllers.Student.Models
{
    /// <summary>
    /// RegistrationCollection
    /// </summary>
    [CollectionDataContract(Name = "registrationCollection", ItemName = "registrationItem")]
    public class RegistrationCollection : List<RegistrationItem>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="size"></param>
        public RegistrationCollection(int size) : base(size) { }

        /// <summary>
        /// Ctor
        /// </summary>
        public RegistrationCollection() { }
    }
}
