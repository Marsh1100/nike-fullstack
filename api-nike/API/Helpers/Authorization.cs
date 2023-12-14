namespace API.Helpers;

public class Authorization
{
    public enum Roles
    {
        Administrator,
        Client,
        WithoutRol
    }
    public const Roles rol_default = Roles.WithoutRol;
}
