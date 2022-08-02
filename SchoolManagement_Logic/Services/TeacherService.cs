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
    public class TeacherService
    {
        private readonly IConnection _db;
        public TeacherService(IConnection db)
        {
            _db = db;
        }
        
            
    }
}
