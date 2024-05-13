using Core.Enums;

namespace BL.Handler.NoteHandler.NoteRequests;
public record ChangePriorityRequest(Guid NoteId, NotesPriority Priority);
