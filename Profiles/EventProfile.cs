using AutoMapper;
using MeetUp.Models;

namespace MeetUp.Profiles;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<Event, EventDTO>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id)
            )
            .ForMember(
                dest => dest.Eventstart,
                opt => opt.MapFrom(src => src.Eventstart)
            )
            .ForMember(
                dest => dest.Topic,
                opt => opt.MapFrom(src => src.Topic)
            )
            .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description)
            )
            .ForMember(
                dest => dest.Plan,
                opt => opt.MapFrom(src => src.Plan)
            )
            .ForMember(
                dest => dest.Speakers,
                opt => opt.MapFrom(src => src.Speakers.Count == 0 ? null : src.Speakers)
            );

        CreateMap<EventDTO, Event>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid())
            )
            .ForMember(
                dest => dest.Eventstart,
                opt => opt.MapFrom(src => src.Eventstart)
            )
            .ForMember(
                dest => dest.Topic,
                opt => opt.MapFrom(src => src.Topic)
            )
            .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description)
            )
            .ForMember(
                dest => dest.Plan,
                opt => opt.MapFrom(src => src.Plan)
            )
            .ForMember(
                dest => dest.Speakers,
                opt => opt.MapFrom(src => src.Speakers ?? new List<string>())
            );
    }
}