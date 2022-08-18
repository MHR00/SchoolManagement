using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement_Model.Models;
using SchoolManagement_Util;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService TeacherService)
        {
            _teacherService = TeacherService;

        }

        [HttpGet]
        public async Task<IResult> GetTeacher()
        {
            try
            {
                return Results.Ok(await _teacherService.GetTeachers());
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetTeacher(int id)
        {
            try
            {
                var results = await _teacherService.GetTeacher(id);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IResult> InsertTeacher(TeacherCreateModel teacher)
        {
            try
            {
                if (MobileNumberRegex.IsValidPhone(teacher.Mobile)&& (Valid_NationalCodeClass.Valid_NC(teacher.NationalCode)))
                {
                    await _teacherService.InsertTeacher(teacher);
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
        public async Task<IResult> UpdataTeacher(TeacherUpdateModel Teacher)
        {
            try
            {
                await _teacherService.UpdateTeacher(Teacher);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IResult> DeleteTeacher(int id)
        {
            try
            {
                await _teacherService.DeleteTeacher(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpGet("{teacherId}/getTeachersStudents")]
        public async Task<IResult> TeachersStudents(int teacherId)
        {
            try
            {
                var results = await _teacherService.GetTeachersStudents(teacherId);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpGet("get/message")]
        public async Task<IResult> GetMessage()
        {
            try
            {
                return Results.Ok(await _teacherService.GetMessages());
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
        [HttpGet("{teacherId}/getMessageByTeacherId")]
        public async Task<IResult> GetMessageByTeacherId(int teacherId)
        {
            try
            {
                var result = await _teacherService.GetMessge_ByTeacherId(teacherId);
                if (result == null) return Results.NotFound();
                return Results.Ok(result);

            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }


    }
}
