using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement_Logic.Services;
using SchoolManagement_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SchoolManagement_Logic.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory ,
            ITeacherService teacherService,
            IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _teacherService = teacherService;
            _mapper = mapper;
        }
        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.MessagePublish:
                    AddMessage(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notifcationMessage)
        {
            Console.WriteLine("--> Determinnig Event");
            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notifcationMessage);

            switch(eventType.Event)
            {
                case "Message_Publisher":
                    Console.WriteLine("--> Platform Published Event Detected");
                    return EventType.MessagePublish;
                default:
                    Console.WriteLine("--> Could not determine the event type");
                    return EventType.Undetermined;
            }
        }

        private void AddMessage(string messagePublishedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<ITeacherService>();

                var messagePublishedDto = JsonSerializer.Deserialize<MessagePublishDto>(messagePublishedMessage);
                var messages = _mapper.Map<MessagePublishDto>(messagePublishedDto);
                try
                {
                    var message = _teacherService.CreateMessage(messages);
                   
                    Console.WriteLine("--> Message added!");
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }


    }

    enum EventType
    {
        MessagePublish,
        Undetermined
    }
}
