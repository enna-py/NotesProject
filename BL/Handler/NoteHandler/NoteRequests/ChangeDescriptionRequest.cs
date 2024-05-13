namespace BL.Handler.NoteHandler.NoteRequests;
public record ChangeDescriptionRequest(Guid NoteId, string Description);
