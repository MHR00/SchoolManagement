using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_Model.Models
{
    public class TeacherModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long NationalCode { get; set; }
        public int Age { get; set; }
        public long Mobile { get; set; }
    }

    public class TeacherCreateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public int Age { get; set; }
        public string Mobile { get; set; }
    }

    public class TeacherUpdateModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long NationalCode { get; set; }
        public int Age { get; set; }
        public string Mobile { get; set; }
    }
}
