using AutoMapper;
using BL.Responses.Note;
using BL.Responses.User;
using DAL.Models;

namespace notesApi.Profiler;

public class AutoMapperProfiler : Profile
{
    public AutoMapperProfiler()
    {
        CreateMap<Note, NoteGetAllResponse>()
                .ConstructUsing(note => new NoteGetAllResponse(note.Id, note.Name, note.Description, note.Group, note.Priority));

        CreateMap<User, UserGetAllResponse>()
            .ConstructUsing(user => new UserGetAllResponse(user.Id, user.UserName));
    }
}

