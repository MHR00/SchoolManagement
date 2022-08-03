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

        //public Task InsertStudent(StudentModel student) =>
        //    _db.SaveData("dbo.spStudent_Insert", new
        //    {
        //        student.FirstName,
        //        student.LastName,
        //        student.NationalCode,
        //        student.Mobile,
        //        student.RegisterDate
        //    });

        public Task InsertStudent(StudentModel student) {
            
            var result = _db.SaveData("dbo.spStudent_Insert", new
            {
                student.FirstName,
                student.LastName,
                student.NationalCode,
                student.Mobile,
                student.RegisterDate
            });
            
            return result;
        }


        public Task UpdateStudent(StudentModel student) =>
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


        public static bool IsValidPhone(string Phone)
        {
            try
            {
                if (string.IsNullOrEmpty(Phone))
                    return false;
                var r = new Regex(@"^(?:0|98|\+98|\+980|0098|098|00980)?(9\d{9})$");
                return r.IsMatch(Phone);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }


}
