using AttendanceEpiisBk.Model.Dtos.Event;
using AttendanceEpiisBk.Model.Dtos.Guest;
using Mapster;
using Microsoft.EntityFrameworkCore;
using AttendanceEpiisBk.Model.Dtos.Teacher;
using AttendanceEpiisBk.Modules.Attendance.Domain.Entity;
using AttendanceEpiisBk.Modules.Event.Application.Port;
using AttendanceEpiisBk.Modules.Event.Domain.Entity;
using AttendanceEpiisBk.Modules.Event.Domain.IRepository;
using AttendanceEpiisBk.Modules.Student.Domain.Entity;
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
    
   public async Task GetParticipantsAsync(int eventId)
{
    var participants = await _eventRepository.GetAllAsync<AttendanceEntity>(
        x => x.Where(s => s.EventId == eventId)
            .Include(s => s.Teacher)
            .Include(s => s.Student)
            .Include(s => s.Guest)
    );

    var participantDtos = new List<ParticipantDto>();

    foreach (var participant in participants)
    {
        if (participant.Teacher != null)
        {
            participantDtos.Add(new ParticipantDto
            {
                FirstName = participant.Teacher.FirstName,
                LastName = participant.Teacher.LastName,
                Role = 0,
                IsPresent = participant.IsPresent,
                Date = participant.Date,
            });
        }

        if (participant.Student != null)
        {
            participantDtos.Add(new ParticipantDto
            {
                FirstName = participant.Student.FirstName,
                LastName = participant.Student.LastName,
                Role = 1,
                IsPresent = participant.IsPresent,
                Date = participant.Date,
            });
        }

        if (participant.Guest != null)
        {
            participantDtos.Add(new ParticipantDto
            {
                FirstName = participant.Guest.FirstName,
                LastName = participant.Guest.LastName,
                Role = 2,
                IsPresent = participant.IsPresent,
                Date = participant.Date,
            });
        }
    }

    _eventOutPort.GetParticipants(participantDtos);
}
    
      public async Task CreateGuest(GuestDto data)
        {
            var existingDto = await _eventRepository.GetAsync<GuestEntity>(x => x.Dni == data.Dni);
            if (existingDto != null)
            {
                _eventOutPort.Error("Ya existe un invitado (  "+existingDto.FirstName+" ) creado con este DNI");
                return;
            }
    
            var guestEntity = data.Adapt<GuestEntity>();
            await _eventRepository.AddAsync(guestEntity);
            await _eventRepository.SaveChangesAsync();
            _eventOutPort.Success(guestEntity, "Teacher created successfully.");
        }
      
        public async Task GetAllGuest()
        {
            var guests = await _eventRepository.GetAllAsync<GuestEntity>( );

            var eventEntities = guests.ToList();
            if (!eventEntities.Any())
            {
                _eventOutPort.NotFound("No tiene Guest");
                return;
            }

            var eventDtos = guests.Adapt<List<GuestDto>>();

            _eventOutPort.GetAllGuest(eventDtos);
        }
   
}