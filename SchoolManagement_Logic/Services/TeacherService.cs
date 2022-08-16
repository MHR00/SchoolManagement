using SchoolManagement_Logic.DbAccesss;
using SchoolManagement_Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_Logic.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ISqlDataAccess _db;
        public static List<MessagePublishDto> messages = new List<MessagePublishDto>();
        public TeacherService(ISqlDataAccess db)
        {
            _db = db;
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

        public List<MessagePublishDto> GetMessages()
        {
            return messages;
        }

        public MessagePublishDto CreateMessage(MessagePublishDto message)
        {
            messages.Add(message);
            return message;

        }
    }
}
