using System.Collections.Generic;

namespace student_listing.Data.DAL
{
    public interface IRegistrationDataAccess
    {
        List<student_listing.Models.Registration> GetRegistrations();
    }
}
