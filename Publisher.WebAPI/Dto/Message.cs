using System.Text.Json.Serialization;

namespace Producer.WebAPI.Dto
{
    public class Messages
    {


        public string Message { get; set; }
      
        public string Event { get; set; } = "MessagePublish";
    }

    public class MessageDto
    {
        public string Message { get; set; }
    }
}
