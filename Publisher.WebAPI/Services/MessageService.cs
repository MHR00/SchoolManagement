using Producer.WebAPI.Dto;

namespace Producer.WebAPI.Services
{
    public class MessageService : IMessageService
    {
        public static List<Messages> messages = new List<Messages>();
        
        public Messages CreateMessage(Messages message)
        {
            messages.Add(message);
            return message;
        }
    }
}
