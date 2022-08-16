using Producer.WebAPI.Dto;

namespace Producer.WebAPI.Services
{
    public interface IMessageService
    {
        Messages CreateMessage(Messages message);
    }
}
