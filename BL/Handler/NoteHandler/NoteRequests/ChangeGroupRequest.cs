using Core.Enums;

namespace BL.Handler.NoteHandler.NoteRequests;
public record ChangeGroupRequest(Guid NoteId, NotesGroup Group);