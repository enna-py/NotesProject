namespace BL.Handler.NoteHandler.NoteRequests;
public record ChangeDeadLineRequest(Guid NoteId, DateTime DeadLine);
