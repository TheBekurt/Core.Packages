using System.Data;

namespace Core.Persistence.Repositories;

public class Entity<TId>(TId? id) : IEntityTimestamps
{
    public TId Id { get; set; } = id;
    

    public Entity() : this(default)
    {

    }

    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}