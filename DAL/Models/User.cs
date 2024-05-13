namespace DAL.Models;
public class User
{
    public Guid Id { get; set; }//empty lines (not necessary)
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public bool IsActive { get; set; }
}
