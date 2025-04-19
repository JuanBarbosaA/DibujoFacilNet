namespace backend.Repositories.Models;

public partial class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual ICollection<User> Users { get; set; } = new List<User>();

    // Constantes definidas dentro del modelo Role
    public static class SystemRoles
    {
        public const int Admin = 1;
        public const int User = 2;
    }
}