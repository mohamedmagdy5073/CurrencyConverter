namespace Application.Shared.Dtos
{
    public abstract class AuditableDto : BaseDto
    {
        public DateTime Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }
    }
}
