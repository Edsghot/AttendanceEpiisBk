using AttendanceEpiisBk.Model.Dtos.Event;
using Mapster;
using Microsoft.EntityFrameworkCore;
using AttendanceEpiisBk.Model.Dtos.Teacher;
using AttendanceEpiisBk.Modules.Event.Application.Port;
using AttendanceEpiisBk.Modules.Event.Domain.Entity;
using AttendanceEpiisBk.Modules.Event.Domain.IRepository;
using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

namespace AttendanceEpiisBk.Modules.Event.Application.Adapter;

public class EventAdapter : IEventInputPort
{
    private readonly IEventOutPort _eventOutPort;
    private readonly IEventRepository _eventRepository;

    public EventAdapter(IEventRepository repository, IEventOutPort eventOutPort)
    {
        _eventRepository = repository;
        _eventOutPort = eventOutPort;
    }

    public async Task GetById(int id)
    {
        var events = await _eventRepository.GetAsync<EventEntity>(
            x => x.IdEvent == id);
        if (events == null)
        {
            _eventOutPort.NotFound("No event found.");
            return;
        }

        var eventDtos = events.Adapt<EventDto>();
        _eventOutPort.GetById(eventDtos);
    }

    public async Task GetAllAsync()
    {
        var events = await _eventRepository.GetAllAsync<EventEntity>( );

        var eventEntities = events.ToList();
        if (!eventEntities.Any())
        {
            _eventOutPort.NotFound("No event found.");
            return;
        }

        var eventDtos = events.Adapt<List<EventDto>>();

        _eventOutPort.GetAllAsync(eventDtos);
    }
    
    public async Task AddEventAsync(EventDto eventDto)
    {
        var eventEntity = eventDto.Adapt<EventEntity>();
        await _eventRepository.AddAsync(eventEntity);
        await _eventRepository.SaveChangesAsync();
        _eventOutPort.EventAdded();
    }
}