using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_Model.Models
{
    public class MessagePublished
    {
        public int TeacherId { get; set; }
        public string Message { get; set; }
    }
    public  class MessagePublishDto
    {
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public string Message { get; set; }

    }

    public class MessageByDoctorIdDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentId { get; set; }
        public string Message { get; set; }
    }
}
