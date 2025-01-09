using AttendanceEpiisBk.Model.Dtos.Attedance;
using Mapster;
using Microsoft.EntityFrameworkCore;
using AttendanceEpiisBk.Model.Dtos.Teacher;
using AttendanceEpiisBk.Modules.Attendance.Application.Port;
using AttendanceEpiisBk.Modules.Attendance.Domain.Entity;
using AttendanceEpiisBk.Modules.Event.Domain.IRepository;
using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

namespace AttendanceEpiisBk.Modules.Attendance.Application.Adapter;

public class AttendanceAdapter : IAttendanceInputPort
{
    private readonly IAttendanceOutPort _eventOutPort;
    private readonly IAttendanceRepository _eventRepository;

    public AttendanceAdapter(IAttendanceRepository repository, IAttendanceOutPort eventOutPort)
    {
        _eventRepository = repository;
        _eventOutPort = eventOutPort;
    }

    public async Task GetById(int id)
    {
        var events = await _eventRepository.GetAsync<AttendanceEntity>(
            x => x.IdAttendance == id);
        if (events == null)
        {
            _eventOutPort.NotFound("No event found.");
            return;
        }

        var eventDtos = events.Adapt<AttendanceDto>();
        _eventOutPort.GetById(eventDtos);
    }

    public async Task GetAllAsync()
    {
        var events = await _eventRepository.GetAllAsync<AttendanceEntity>( );

        var eventEntities = events.ToList();
        if (!eventEntities.Any())
        {
            _eventOutPort.NotFound("No event found.");
            return;
        }

        var eventDtos = events.Adapt<List<AttendanceDto>>();

        _eventOutPort.GetAllAsync(eventDtos);
    }
}