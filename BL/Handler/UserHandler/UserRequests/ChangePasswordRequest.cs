namespace BL.Handler.UserHandler.UserRequests;
public record ChangePasswordRequest(Guid UserId, string NewPassword);
