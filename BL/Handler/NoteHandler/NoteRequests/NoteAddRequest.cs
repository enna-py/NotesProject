namespace BL.Handler.NoteHandler.NoteRequests;
public record NoteAddRequest(string Name, string Description, Guid UserId);
