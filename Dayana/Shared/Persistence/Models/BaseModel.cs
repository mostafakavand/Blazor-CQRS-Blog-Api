
namespace Dayana.Shared.Persistence.Models;
public record BaseModel
{
    public int Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}
