﻿using SchoolManagement_Model.Models;

namespace SchoolManagement_Logic.Services
{
    public interface ITeacherService
    {
        Task DeleteTeacher(int id);
        Task<TeacherModel?> GetTeacher(int id);
        Task<IEnumerable<TeacherModel>> GetTeachers();
        Task InsertTeacher(TeacherModel teacher);
        Task UpdateTeacher(TeacherModel teacher);
        Task<IEnumerable<TeachersStudentsModel?>> GetTeachersStudents(int id);
    }
}