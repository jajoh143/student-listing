using System.Collections.Generic;

namespace student_listing.Data.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int Score { get; set; }
        public string Letter { get; set; }
        public ICollection<Registration> Registrations { get; set; }
    }
}
