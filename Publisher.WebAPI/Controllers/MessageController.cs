using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Producer.WebAPI.Dto;
using Producer.WebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Producer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageBusClient _messageBusClient;
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageBusClient messageBusClient,
            IMessageService messageService,
            IMapper mapper)
        {
            _messageBusClient = messageBusClient;
            _messageService = messageService;
            _mapper = mapper;
        }
        // GET: api/<MessageController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MessageController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MessageController>
        [HttpPost]
        public void Post(MessageDto message)
        {
            try
            {
                var finalMessages = _mapper.Map<Messages>(message);
                finalMessages.Event = "Message_Publisher";
                _messageBusClient.PublishMessage(finalMessages);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"--> Could not send message {ex.Message}");
            }
        }

        // PUT api/<MessageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
