using AutoMapper;
using SchoolManagement_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_Logic.Profiles
{
    public class AutoMappeProfile:Profile
    {
        public AutoMappeProfile()
        {
            CreateMap<MessagePublished, MessagePublishDto>();
        }
    }
}
