using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using student_listing.Business.RegistrationBusiness;
using student_listing.Business.StudentBusiness;
using student_listing.Controllers.RegistrationController.Models;
using student_listing.Controllers.StudentController.Models;
using student_listing.Web.Controllers.StudentController.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Controllers.StudentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        /// <summary>
        /// Student Business
        /// </summary>
        private IRegistrationBusiness _registrationBusiness { get; set; }

        public RegistrationController(IRegistrationBusiness registrationBusiness)
        {
            _registrationBusiness = registrationBusiness;
        }

        [HttpPost]
        public async Task<ActionResult<CreateStudentRegistrationParam>> Post([FromBody] CreateStudentRegistrationParam registrationParams)
        {
            return Ok(new CreateStudentRegistrationResult(await _registrationBusiness.CreateStudentRegistration(registrationParams.StudentId, registrationParams.CourseId)));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteStudentRegistrationResult>> Delete(int id)
        {
            return Ok(new DeleteStudentRegistrationResult(await _registrationBusiness.RemoveStudentRegistration(id)));
        }
    }
}
