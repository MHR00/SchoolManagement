﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement_Model.Models;

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
        public async Task<IResult> InsertTeacher(TeacherModel Teacher)
        {
            try
            {
                await _teacherService.InsertTeacher(Teacher);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IResult> UpdataTeacher(TeacherModel Teacher)
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
    }
}
