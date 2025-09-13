namespace SilentMike.Gielda.Commision.Domain.Common.Interfaces;

using SilentMike.Gielda.Commision.Domain.Types;

public interface IEntity<out TId> where TId : IEntityId, new()
{
    public TId Id { get; }
}
