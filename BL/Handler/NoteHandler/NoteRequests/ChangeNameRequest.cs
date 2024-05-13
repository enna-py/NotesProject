namespace BL.Handler.NoteHandler.NoteRequests;
public record ChangeNameRequest(Guid NoteId, string NewName);
