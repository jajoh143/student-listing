using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using student_listing.Business.GradeBusiness;
using student_listing.Business.StudentBusiness;
using student_listing.Controllers.GradeController.Models;
using student_listing.Controllers.StudentController.Models;
using student_listing.Web.Controllers.StudentController.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Controllers.GradeController
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        /// <summary>
        /// Grade Business
        /// </summary>
        private IGradeBusiness _gradeBusiness { get; set; }

        public GradeController(IGradeBusiness gradeBusiness)
        {
            _gradeBusiness = gradeBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<GetGradeList>> Get()
        {
            return Ok(new GetGradeList(await _gradeBusiness.GetGrades()));
        }
    }
}
