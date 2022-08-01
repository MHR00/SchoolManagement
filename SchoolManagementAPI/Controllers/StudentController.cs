using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement_Model.Models;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        [HttpGet]
        public async Task<IResult> GetStudent(IStudentService data)
        {
            try
            {
                return Results.Ok(await data.GetStudents());
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IResult> InsertStudent(StudentModel student)
        {
            try
            {
                await _studentService.InsertStudent(student);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
    }
}
