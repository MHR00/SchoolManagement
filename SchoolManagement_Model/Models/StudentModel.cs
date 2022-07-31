using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_Model.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public int NationalCode { get; set; }
        public int Mobile { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
