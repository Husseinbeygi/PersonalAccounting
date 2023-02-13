namespace Domain.SeedWork
{
    public interface IEntityHasIsDeleted
    {
        bool IsDeleted { get; }

        DateTime? DeleteDateTime { get; }

        void SetDeleteDateTime();
    }
}
