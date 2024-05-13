namespace BL.Handler.UserHandler.UserRequests;
public record ChangeNameUserRequest(Guid UserId, string NewName);
