using AutoMapper;
using Producer.WebAPI.Dto;

namespace Producer.WebAPI.Profiles
{
    public class AutoMappeProfile:Profile
    {
        public AutoMappeProfile()
        {
            CreateMap<MessageDto, Messages>();
        }
    }
}
