using BL.Handler.NoteHandler.NoteRequests;
using BL.Responses.Note;
using DAL.Models;

namespace BL.Interfaces;
public interface IServiceNote
{
    public Task<Note> GetByIdAsync(Guid Id);

    public Task<IEnumerable<NoteGetAllResponse>> GetAllAsync();

    public Task<Guid> AddNoteAsync(NoteAddRequest request);

    public Task<bool> ChangeColor(ChangeColorRequest request);

    public Task<bool> ChangeDescription(ChangeDescriptionRequest request);

    public Task<bool> ChangeGroup(ChangeGroupRequest request);

    public Task<bool> ChangeName(ChangeNameRequest request);

    public Task<bool> ChangePriority(ChangePriorityRequest request);

    public Task<bool> DeleteNote(Guid Id);

    public Task<bool> ChangeDeadLine(ChangeDeadLineRequest request);

    public Task<bool> ChangeDone(ChangeIsDoneRequest request);
}
