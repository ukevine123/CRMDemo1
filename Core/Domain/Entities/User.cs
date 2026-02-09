using System.Dynamic;

namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}