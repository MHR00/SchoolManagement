using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_Model.Models
{
    public  class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Tuition { get; set; }   
    }

    public class CourseCreateModel
    {
      
        public string Name { get; set; }
        public long Tuition { get; set; }
    }

    public class CourseUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Tuition { get; set; }
    }


}
