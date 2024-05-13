namespace BL.Handler.UserHandler.UserRequests;
public record ChangeEmailRequest(Guid UserId, string Email);
