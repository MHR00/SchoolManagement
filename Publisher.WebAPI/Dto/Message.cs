using System.Text.Json.Serialization;

namespace Producer.WebAPI.Dto
{
    public class Messages
    {
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public string Message { get; set; }
      
        public string Event { get; set; } = "MessagePublish";
    }

    public class MessageDto
    {
        public int StudentId { get; set; }
        public string Message { get; set; }
        public int TeacherId { get; set; }
    }
}
