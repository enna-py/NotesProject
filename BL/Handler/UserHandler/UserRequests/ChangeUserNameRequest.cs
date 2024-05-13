namespace BL.Handler.UserHandler.UserRequests;
public record ChangeUserNameRequest(Guid UserId, string NewUserName);
