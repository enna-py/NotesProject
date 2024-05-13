using AutoMapper;
using BL.Handler.NoteHandler.NoteRequests;
using BL.Interfaces;
using BL.Responses.Note;
using Core.Enums;
using Core.Exeptions;
using DAL.Interface;
using DAL.Models;

namespace BL.Services;
public class NoteService : IServiceNote
{
    private readonly INoteRepository _noteRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public NoteService(INoteRepository noteRepository, IMapper mapper, IUserRepository userRepository)
    {
        _noteRepository = noteRepository;
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public async Task<Guid> AddNoteAsync(NoteAddRequest request)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            throw new EntityNotFoundException($"User with id: {request.UserId} was not found");
        }

        var noteDb = new Note()
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            Name = request.Name,
            Description = request.Description,
            IsActive = true,
            IsDone = false,
            Colors = NotesColor.Green,
            Group = NotesGroup.None,
            Priority = NotesPriority.None,
        };

        return await _noteRepository.AddNoteAsync(noteDb);
    }
    //rework all changers to use either generic method
    public async Task<bool> ChangeColor(ChangeColorRequest request)
    {
        var note = await _noteRepository.GetByIdAsync(request.NoteId);
        if (note == null)
        {
            throw new EntityNotFoundException($"Note with id: {request.NoteId} was not found");
        }

        note.Colors = request.Color;
        return await _noteRepository.UpdateAsync(note);
    }

    public async Task<bool> ChangeDescription(ChangeDescriptionRequest request)
    {
        var note = await _noteRepository.GetByIdAsync(request.NoteId);
        if (note == null)
        {
            throw new EntityNotFoundException($"Note with id: {request.NoteId} was not found");
        }

        note.Description = request.Description;
        return await _noteRepository.UpdateAsync(note);
    }

    public async Task<bool> ChangeGroup(ChangeGroupRequest request)
    {
        var note = await _noteRepository.GetByIdAsync(request.NoteId);
        if (note == null)
        {
            throw new EntityNotFoundException($"Note with id: {request.NoteId} was not found");
        }

        note.Group = request.Group;
        return await _noteRepository.UpdateAsync(note);
    }

    public async Task<bool> ChangeName(ChangeNameRequest request)
    {
        var note = await _noteRepository.GetByIdAsync(request.NoteId);
        if (note == null)
        {
            throw new EntityNotFoundException($"Note with id: {request.NoteId} was not found");
        }

        note.Name = request.NewName;
        return await _noteRepository.UpdateAsync(note);
    }

    public async Task<bool> ChangePriority(ChangePriorityRequest request)
    {
        var note = await _noteRepository.GetByIdAsync(request.NoteId);
        if (note == null)
        {
            throw new EntityNotFoundException($"Note with id: {request.NoteId} was not found");
        }

        note.Priority = request.Priority;
        return await _noteRepository.UpdateAsync(note);
    }

    public async Task<IEnumerable<NoteGetAllResponse>> GetAllAsync()
    {
        var allNotes = await _noteRepository.GetAllNotesAsync();
        if(allNotes == null)
        {
            return new List<NoteGetAllResponse>();
        }

        return _mapper.Map<IEnumerable<NoteGetAllResponse>>(allNotes);
    }

    public async Task<Note> GetByIdAsync(Guid Id)
    {
        var note = await _noteRepository.GetByIdAsync(Id);
        if (note == null)
        {
            throw new EntityNotFoundException($"Note with id: {Id} was not found");
        }

        return note;
    }

    public async Task<bool> DeleteNote(Guid Id)
    {
        var note = await _noteRepository.GetByIdAsync(Id);
        if (note == null)
        {
            throw new EntityNotFoundException($"Note with id: {Id} was not found");
        }

        return await _noteRepository.SoftDeleteAsync(Id);
    }
    public async Task<bool> ChangeDeadLine(ChangeDeadLineRequest request)
    {
        var note = await _noteRepository.GetByIdAsync(request.NoteId);
        if (note == null)
        {
            throw new EntityNotFoundException($"Note with id: {request.NoteId} was not found");
        }

        note.DeadLine = request.DeadLine;
        return await _noteRepository.UpdateAsync(note);
    }
    public async Task<bool> ChangeDone(ChangeIsDoneRequest request)
    {
        var note = await _noteRepository.GetByIdAsync(request.NoteId);
        if (note == null)
        {
            throw new EntityNotFoundException($"Note with id: {request.NoteId} was not found");
        }

        note.IsDone= !note.IsDone;

        note.IsActive = false;
        return await _noteRepository.UpdateAsync(note);
    }
}
