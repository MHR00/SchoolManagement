using Producer.WebAPI.Dto;

namespace Producer.WebAPI.Services
{
    public interface IMessageBusClient
    {
        void PublishMessage(Messages messageDto);
    }
}
