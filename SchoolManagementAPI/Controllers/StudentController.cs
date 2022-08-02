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
        private readonly ISqlDataAccess _db;
        public StudentController(IStudentService studentService, ISqlDataAccess db)
        {
            _studentService = studentService;
            _db = db;
        }

        [HttpGet]
        public async Task<IResult> GetStudent()
        {
            try
            {
                return Results.Ok(await _studentService.GetStudents());
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        //[HttpGet("{id}")]
        //public async Task<IResult> GetStudent(int id)
        //{
        //    try
        //    {
        //        var results = await _studentService.GetStudent(id);
        //        if (results == null) return Results.NotFound();
        //        return Results.Ok(results);
        //    }
        //    catch (Exception ex)
        //    {

        //        return Results.Problem(ex.Message);
        //    }
        //}

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

        [HttpPut]
        public async Task<IResult> UpdataStudent(StudentModel student)
        {
            try
            {
                await _studentService.UpdateStudent(student);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IResult> DeleteStudetn(int id)
        {
            try
            {
                await _studentService.DeleteStudent(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<StudentModel?> GetStudentsCourse(int id)
        {
            var results = await _db.LoadData<StudentModel, dynamic>(
                "dbo.spStudentsCourse_Get",
                new { Id = id });
            return results.FirstOrDefault();
        }



    }
}
