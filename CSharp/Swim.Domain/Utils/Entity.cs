namespace Swim.Domain.Utils
{
    [Serializable]
    public class Entity<ID>
    {
        public ID? Id { get; set; } = default;
    }
}
