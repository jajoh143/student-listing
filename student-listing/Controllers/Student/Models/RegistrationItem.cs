using System.Runtime.Serialization;

namespace student_listing.Web.Controllers.Student.Models
{
    /// <summary>
    /// RegistrationItem
    /// </summary>
    [DataContract(Name = "registrationItem")]
    public class RegistrationItem
    {
        /// <summary>
        /// Id
        /// </summary>
        [DataMember(Name = "id", Order = 0)]
        public int Id { get; set; }
        
        /// <summary>
        /// CourseName
        /// </summary>
        [DataMember(Name = "courseName", Order = 0)]
        public string CourseName { get; set; }
        
        /// <summary>
        /// Grade
        /// </summary>
        [DataMember(Name = "grade", Order = 0)]
        public string Grade { get; set; }
    }
}
