using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement_Model.Models;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService CourseService)
        {
            _courseService = CourseService;

        }

        [HttpGet]
        public async Task<IResult> GetCourse()
        {
            try
            {
                return Results.Ok(await _courseService.GetCourses());
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetCourse(int id)
        {
            try
            {
                var results = await _courseService.GetCourse(id);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IResult> InsertCourse(CourseCreateModel course)
        {
            try
            {
                await _courseService.InsertCourse(course);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IResult> UpdataCourse(CourseUpdateModel course)
        {
            try
            {
                await _courseService.UpdateCourse(course);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IResult> DeleteCourse(int id)
        {
            try
            {
                await _courseService.DeleteCourse(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
    }
}
