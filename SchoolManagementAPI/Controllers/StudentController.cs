using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement_Model.Models;
using SchoolManagement_Util;
using System.Data;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
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

        [HttpGet("{id}")]
        public async Task<IResult> GetStudent(int id)
        {
            try
            {
                var results = await _studentService.GetStudent(id);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IResult> InsertStudent(StudentCreateModel student)
        {
            try
            {
                if (MobileNumberRegex.IsValidPhone(student.Mobile))
                {
                    await _studentService.InsertStudent(student);
                    return Results.Ok();
                }
                else return Results.BadRequest();
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
        public async Task<IResult> DeleteStudent(int id)
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

        [HttpGet("{studentId}/getstudentcourse")]
        public async Task<IResult> GetStudentCourse(int studentId)
        {
            try
            {
                var results = await _studentService.GetStudentsCourse(studentId);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpGet("{studentId}/getStudentsTeachers")]
        public async Task<IResult> GetStudentsTeachers(int studentId)
        {
            try
            {
                var results = await _studentService.GetStudentsTeachers(studentId);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpGet("{studentId}/getTotalTuition")]
      public async Task<IResult> GetTotalTuition(int studentId)
        {
            try
            {
                var results = await _studentService.GetTotalTuition(studentId);
                if(results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }





    }
}
