using Microsoft.Extensions.Configuration;
using SchoolManagement_Logic.DbAccesss;
using SchoolManagement_Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement_Logic.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ISqlDataAccess _db;
        private readonly IConfiguration _config;
        public static List<MessagePublishDto> messages = new List<MessagePublishDto>();
       
        public TeacherService(ISqlDataAccess db , IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public Task<IEnumerable<TeacherModel>> GetTeachers() =>
            _db.LoadData<TeacherModel, dynamic>("dbo.spTeacher_GetAll", new { });


        public async Task<TeacherModel?> GetTeacher(int id)
        {
            var results = await _db.LoadData<TeacherModel, dynamic>(
                "dbo.spTeacher_Get",
                new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertTeacher(TeacherCreateModel teacher) =>
            _db.SaveData("dbo.spTeacher_Insert", new
            {
                teacher.FirstName,
                teacher.LastName,
                teacher.NationalCode,
                teacher.Age,
                teacher.Mobile
            });

        public Task UpdateTeacher(TeacherUpdateModel teacher) =>
            _db.SaveData("dbo.spTeacher_Update", teacher);

        public Task DeleteTeacher(int id) =>
            _db.SaveData("dbo.spTeacher_Delete", new { Id = id });

        public async Task<IEnumerable<TeachersStudentsModel?>> GetTeachersStudents(int id)
        {
            var results = await _db.LoadData<TeachersStudentsModel, dynamic>(
                "dbo.spTeachersStudents_Get",
                new { Id = id });
            return results.ToList();
        }

        public Task CreateMessage(MessagePublishDto message) =>

            _db.SaveData("dbo.spMessage_Insert", message);

        public Task<IEnumerable<MessagePublishDto>> GetMessages() =>
               _db.LoadData<MessagePublishDto, dynamic>("dbo.spMessage_GetAll", new { });

        public async Task<IEnumerable<MessageByDoctorIdDto?>> GetMessge_ByTeacherId(int id)
        {
            var results = await _db.LoadData<MessageByDoctorIdDto, dynamic>(
                "dbo.spMessage_GetByTeacherId",
                new { Id = id });
            return results.ToList();
        }


    }
}
