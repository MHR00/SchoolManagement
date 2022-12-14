using SchoolManagement_Logic.DbAccesss;
using SchoolManagement_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolManagement_Logic.Services
{


    public class StudentService : IStudentService
    {
        private readonly ISqlDataAccess _db;
        public StudentService(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<StudentModel>> GetStudents() =>
            _db.LoadData<StudentModel, dynamic>("dbo.spStudent_GetAll", new { });


        public async Task<StudentModel?> GetStudent(int id)
        {
            var results = await _db.LoadData<StudentModel, dynamic>(
                "dbo.spStudent_Get",
                new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertStudent(StudentCreateModel student) =>
            _db.SaveData("dbo.spStudent_Insert", new
            {
                student.FirstName,
                student.LastName,
                student.NationalCode,
                student.Mobile,

            });

        public Task UpdateStudent(StudentUpdateModel student) =>
            _db.SaveData("dbo.spStudent_Update", student);

        public Task DeleteStudent(int id) =>
            _db.SaveData("dbo.spStudent_Delete", new { Id = id });

        public async Task<StudentCourseModel?> GetStudentsCourse(int id)
        {
            var results = await _db.LoadData<StudentCourseModel, dynamic>(
                "dbo.spStudentsCourse_Get",
                new { Id = id });
            return results.FirstOrDefault();
        }

        public async Task<IEnumerable<StudentsTeachersModel?>> GetStudentsTeachers(int id)
        {
            var results = await _db.LoadData<StudentsTeachersModel, dynamic>(
                "dbo.spStudentsTeacher_Get",
                new { Id = id });
            return results.ToList();
        }

        public async Task<StudentsTotalTuitionModel> GetTotalTuition(int studentId)
        {
            var results = await _db.LoadData<StudentsTotalTuitionModel, dynamic>(
                "dbo.spStudentsTotalTuition_Get",
                new { Id = studentId });
            return results.FirstOrDefault();
        }





    }


}
