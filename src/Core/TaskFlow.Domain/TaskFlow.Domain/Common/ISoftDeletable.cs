namespace TaskFlow.Domain.Common;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
    DateTime? DeletedDate {  get; set; }
    string? DeletedBy { get; set; }
}
