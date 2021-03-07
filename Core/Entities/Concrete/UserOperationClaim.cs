namespace Core.Entities.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public int UserId;

        public int Id { get; set; }
        public string Name { get; set; }
        public int OperationClaimId { get; set; }
    }
}
