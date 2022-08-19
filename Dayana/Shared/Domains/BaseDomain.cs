using Dayana.Shared.Basic.MethodsAndObjects.Models;

namespace Dayana.Shared.Domains;

public class BaseDomain : IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
